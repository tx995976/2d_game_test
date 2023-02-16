namespace Obj.sp_player.status;

public partial class state_equip_aim :Node, IstateNode
{
	Iwalkable? Source;
	Node2D? Source2d;

	public string? name => Name;

	public event Action<StringName, stc_mode>? change_state;

	public override void _Ready() {
		Source = (Iwalkable)Owner;
		Source2d = (Node2D)Owner;
	}

	public override void _PhysicsProcess(double delta) {
		Source!.view_dir = Source2d!.GetLocalMousePosition();

	}

	public void action_input(InputEvent @event) {
		//if(@event.IsActionReleased(""))
			change_state?.Invoke("",stc_mode.st_ret);
	}


	public void enter_state() {
		if(Source is IroleController controller)
			controller.inputSource += action_input;
		SetPhysicsProcess(true);
	}

	public void exit_state() {
		if(Source is IroleController controller)
			controller.inputSource -= action_input;
		SetPhysicsProcess(false);
	}
}