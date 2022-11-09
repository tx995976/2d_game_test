using Godot;
using System;
using Godot.Collections;
using System.Collections.Generic;


public partial class sp_state_machine : Node
{
	[Export]
	Godot.Collections.Dictionary<string,sp_status> st_map = new Godot.Collections.Dictionary<string, sp_status>();

	Stack<sp_status> st_stack = new Stack<sp_status>();
	
	[Export]
	bool is_active;

	[Export]
	string start_state;

	[Export]
	sp_status status_now;

	public enum st_mode{
		st_push,
		st_swap,
		st_ret,
	}

	public override void _Ready(){
		foreach(var child in GetChildren()){

			st_map[child.Name] = (sp_status)child;
		}

		is_active = true;
		status_now = st_map[start_state];
		status_now.enter_st();
	}

	public void _state_change(int mode,string name_st){
		if(!is_active)
			return;

		#if DEBUG
		GD.Print($"change to {status_now.Name}");
		#endif

		status_now.exit_st();
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

		status_now.enter_st();
		return;
	}

}
