using Godot;
using static Godot.GD;

using Obj.ui;

namespace Obj.Event;
/*
	//触发器(按钮)
	@主动检测 sp -> area
	@ui同步 -> "%ui_tips"
	@触发 player ->[Input]"action_pressed"

*/
public partial class ev_trigger_button : ev_trigger_root
{

	[Signal]
	public delegate void ev_button_pressedEventHandler();


	bool _touched = false;

	ui_tips? ui_node;

	public override void _Ready(){
		BodyEntered += sp_enter;
		BodyExited += sp_exit;

		ui_node = GetNode("%ui_tips") as ui_tips;
	}

	public override void sp_enter(Node2D body){
		_touched = true;
		AddToGroup("sp_button");
		ui_node?._show_tips("button_tips");
	}
	
	public override void sp_exit(Node2D body){
		if(_touched)
			RemoveFromGroup("sp_button");
		ui_node?._exit_tips();
	}

	public virtual void _action_be_pressed(){
		_touched = false;
		RemoveFromGroup("sp_button");
		if(target_type == tar_limit.Once)
			Monitoring = false;
		ui_node?._exit_tips();
		GetTree().CallGroup(("group_trigger_"+this.Name),"_action_be_trigger");
	}

}
