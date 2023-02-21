namespace Obj.sp_player.status;

public partial class state_idle :Node, IstateNode
{
    Iwalkable? source;

    public string? name => "idle";

    public event Action<StringName, stc_mode>? change_state;

    public override void _PhysicsProcess(double delta) {
        if (source!.velocity_dir != Vector2.Zero)
            change_state?.Invoke("walk", stc_mode.st_swap);
    }

    public void enter_state() {
        SetPhysicsProcess(true);
    }

    public void exit_state() {
        SetPhysicsProcess(false);
    }
}