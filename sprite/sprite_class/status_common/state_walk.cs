namespace Obj.sp_player.status;

public partial class state_walk :Node, IstateNode
{
	Iwalkable? Source;

	public string name => "walk";

	public event Action<StringName, stc_mode>? change_state;

	public override void _Ready() {
		SetPhysicsProcess(false);
		Source = (Iwalkable)Owner;

	}

	public override void _PhysicsProcess(double delta) {
		if (Source!.velocity_dir == Vector2.Zero){
			change_state?.Invoke("idle", stc_mode.st_swap);
			return;
		}

		Source.view_dir = Source.velocity_dir;
		Source.walk(delta);
	}

	public void enter_state() {
		SetPhysicsProcess(true);
	}

	public void exit_state() {
		SetPhysicsProcess(false);
	}
}
