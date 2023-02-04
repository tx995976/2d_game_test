namespace Obj.sp_player.status;

public partial class state_walk :Node, IstateNode
{
    Iwalkable? source;

    public string? name => Name;

    public event Action<string, stc_mode>? change_state;

    public override void _Ready() {
        source = (Iwalkable)Owner;
    }

    public override void _PhysicsProcess(double delta) {
        if (source!.velocity_dir == Vector2.Zero)
            change_state?.Invoke("idle", stc_mode.st_swap);
        //source.MoveAndCollide(node_player.mov_dir * (float)(node_player.speed * delta));

        //issue: walk 
        source.walk();

    }

    public void enter_state() {
        SetPhysicsProcess(true);
    }

    public void exit_state() {
        SetPhysicsProcess(false);
    }
}