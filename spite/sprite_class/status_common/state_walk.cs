namespace Obj.sp_player.status;

public partial class state_walk :Node, IstateNode
{
    Iwalkable? Source;

    public string? name => Name;

    public event Action<StringName, stc_mode>? change_state;

    public override void _Ready() {
        Source = (Iwalkable)Owner;
    }

    public override void _PhysicsProcess(double delta) {
        if (Source!.velocity_dir == Vector2.Zero)
            change_state?.Invoke("idle", stc_mode.st_swap);
        Source.view_dir = Source.velocity_dir;
        //issue: walk 
        Source.walk();

    }

    public void enter_state() {
        SetPhysicsProcess(true);
    }

    public void exit_state() {
        SetPhysicsProcess(false);
    }
}