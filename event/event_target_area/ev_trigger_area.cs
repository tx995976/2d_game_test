using System.Collections.Generic;
using static Godot.GD;


namespace Obj.Event;
//触发器(区域)
/*
	@主动检测 area -> sp
	@sp_enter -> [node]:_action_be_target()
	@in_game_event -> (Node)event_handler

	@触发次数:(一次,多次)
	@通知单位:(Group[ev_area_id])
*/
public partial class ev_trigger_area :ev_trigger_root
{

    bool flag_tar = false;

    public override void _Ready() {
        BodyEntered += sp_enter;

        return;
    }

    public override void sp_enter(Node2D body) {
        if (flag_tar && target_type == tar_limit.Once)
            return;
        flag_tar = true;
        GetTree().CallGroup(("group_trigger_" + this.Name), "_action_be_trigger");
#if DEBUG
        Print((object)(body.Name + " trigger!"));
#endif

    }

}

public partial class trigger_area :Area2D, Itrigger
{
    public Itrigger.trigger_limit target_type { get; set; }
    public bool Is_trigger { get; set; }

    public event Action? trigger_event;

    public override void _EnterTree() {
        BodyEntered += sp_enter;
        BodyExited += sp_exit;
    }

    public void sp_enter(Node2D body) {
        if (Is_trigger)
            return;
        trigger_exec();
    }

    public void sp_exit(Node2D body) {
        if (target_type is Itrigger.trigger_limit.Infinite)
            Is_trigger = false;
    }

    public void trigger_exec() {
        trigger_event?.Invoke();
    }

}
