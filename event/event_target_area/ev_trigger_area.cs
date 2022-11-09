using Godot;
using static Godot.GD;

//触发器(区域)
/*
	@主动检测 area -> sp
	@sp_enter -> [node]:_action_be_target()
	@in_game_event -> (Node)event_handler

	@触发次数:(一次,多次)
	@通知单位:(Group[ev_area_id])
*/
public partial class ev_trigger_area : ev_trigger_root
{

	bool flag_tar = false;

	public override void _Ready(){
		BodyEntered += sp_enter;
		
		return;
	}

	public override void sp_enter(Node2D body){
		if(flag_tar && target_type == tar_limit.Once)
			return;
		flag_tar = true;
		GetTree().CallGroup(("group_triggeer_"+this.Name),"_action_be_trigger");
		#if DEBUG
		Print((object)(body.Name+" trigger!"));
		#endif

	}

}
