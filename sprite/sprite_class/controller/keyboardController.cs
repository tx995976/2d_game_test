namespace Obj.sp_player;

//
public partial class keyboardController : Node, IroleController
{
	Iwalkable? walkSource;

	Action<InputEvent>? _inputSource;

	public Icontrollable? ctrlSource {
		get => _player;
		set {
			if(value is null)
				isActive = false;
			else
				_Redirect(value);

			_player = value;
		} 
	}
	Icontrollable? _player;

	public bool isActive {
		get => _active;
		set {
			SetPhysicsProcess(value);
			SetProcessUnhandledInput(value);
			_active = value;
		}
	}
	bool _active = false;

	public override void _Ready() {
		SetPhysicsProcess(false);
		SetProcessUnhandledInput(false);
	}

	public void _Redirect(Icontrollable ctrlnode) {
		isActive = true;

		if(ctrlnode is Iwalkable walkable)
			walkSource = walkable;
		else{
			SetPhysicsProcess(false);
			walkSource = null;
		}

#if DEBUG
		logLine.info("sprite",$"controll {((Node)ctrlnode)}");
		logLine.info("sprite",$"physics input: {(walkSource == null ? false : true)}");
		
#endif

	}


	public override void _PhysicsProcess(double delta) {
		walkSource!.velocity_dir = Input.GetVector("action_left", "action_right", "action_up", "action_down");
		//issue: view_dir?
	}

	public override void _UnhandledInput(InputEvent @event) {
		ctrlSource!.inputSource?.Invoke(@event);
		// GD.Print($"input {@event}");
	}


}
