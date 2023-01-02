using Godot;
using System.Collections.Generic;

namespace Obj.sp_player;

/*
# 下推状态自动机
	@st_mode->(swap,return,push)

*/

public partial class sp_state_machine : Node
{
	[Export]
	Godot.Collections.Dictionary<string,sp_status> st_map;

	Stack<sp_status> st_stack = new Stack<sp_status>();
	
	[Export]
	public bool is_active;

	[Export]
	public sp_status start_state;

	[Export]
	public sp_status status_now;

	public enum st_mode{
		st_push,
		st_swap,
		st_ret,
	}

	public override void _Ready(){
		st_map = new Godot.Collections.Dictionary<string,sp_status>();
		//init sp_status
		foreach(sp_status child in GetChildren()){
			st_map[child.Name] = child;
			child.status_change += _state_change;
		}
		//enter_st
		status_now = start_state;
		status_now?.enter_st();
	}

	public void _state_change(int mode,string name_st){
		if(!is_active)
			return;

		#if DEBUG
		GD.Print($"change to {status_now.Name}");
		#endif

		status_now?.exit_st();
		switch((st_mode)mode){
			case st_mode.st_push:
				st_stack.Push(status_now);
				status_now = st_map[name_st];
				break;
			case st_mode.st_swap:
				status_now = st_map[name_st];
				break;
			case st_mode.st_ret:
				status_now = st_stack.Pop();
				break;
		}

		EmitSignal(nameof(this.state_change),name_st);
		status_now?.enter_st();
		return;
	}

	[Signal]
	public delegate void state_changeEventHandler(string name);

}
