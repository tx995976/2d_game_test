using Godot;
using static Godot.GD;

//触发器(区域)
/*
@[signal]body_enter ->  sp_enter
@sp_enter -> [node]:_action_be_target()
@in_game_event -> (Node)event_handler

@触发次数:(一次,多次)
@通知单位:(Group[ev_area_id])
*/

public partial class ev_target_area : Area2D{
	[Signal]
	public delegate void ev_targetEventHandler();

	[Export(PropertyHint.Enum)]
	public tar_limit target_type = tar_limit.Once;

	public enum tar_limit{
		Once,
		Infinite
	}

	bool flag_tar = false;

	public override void _Ready(){
		BodyEntered += sp_enter;
		return;
	}

	public void sp_enter(Node2D body){
		if(flag_tar && target_type == tar_limit.Once)
			return;
		flag_tar = true;
		GetTree().CallGroup(("ev_area_"+this.Name),"_action_be_target");
		Print((object)(this.Name+this.GetRid()+" be target!"));
	}

	public void st_reset(){


	}

}
