namespace Obj.sp_player.status;

using System;

public partial class st_idle :sp_status
{

}

public partial class state_idle : Node, IstateNode
{
	Iwalkable? source;

	public string? name => Name;

	public event Action<string, stc_mode>? change_state;

	public override void _PhysicsProcess(double delta) {
		if (source!.velocity_dir != Vector2.Zero)
			change_state?.Invoke("walk", stc_mode.st_swap);
	}

	public void enter_state()
	{
		throw new NotImplementedException();
	}

	public void exit_state()
	{
		throw new NotImplementedException();
	}
}