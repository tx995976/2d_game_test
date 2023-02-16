namespace Obj.sp_player;

public partial class keyboardController :Node, IroleController
{
    Iwalkable? Source;

    public event Action<InputEvent>? inputSource;


    public override void _Ready() {
        Source = Owner as Iwalkable;

        if(Source is null)
            GD.Print(this + "get source failed");

        SetProcessInput(true);
        SetProcessUnhandledInput(true);
    }

    public override void _PhysicsProcess(double delta){
        Source!.velocity_dir = Input.GetVector("action_left","action_right","action_up","action_down");

    }

    public override void _UnhandledInput(InputEvent @event){
        inputSource?.Invoke(@event);

    }


}