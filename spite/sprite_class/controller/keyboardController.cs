namespace Obj.sp_player;

public partial class keyboardController : Node, IroleController
{
	Iwalkable? Source;
	Icontrollable? _controllNode;

	Action<InputEvent>? _inputSource;

	public bool isActive {
		get => _active;
		set
		{
			SetProcessInput(value);
			SetProcessUnhandledInput(value);
			_active = value;
		}
	}
	bool _active = true;

	public override void _EnterTree() {
		Source = Owner as Iwalkable;
		if (Source is null)
			GD.Print(this + "get source failed");

		if (Source is Icontrollable controllNode)
		{
			_controllNode = controllNode;
			GD.Print("controlling", controllNode);
		}

	}


	public override void _PhysicsProcess(double delta) {
		Source!.velocity_dir = Input.GetVector("action_left", "action_right", "action_up", "action_down");

	}

	public override void _UnhandledInput(InputEvent @event) {
		_controllNode!.inputSource?.Invoke(@event);
	}


}
