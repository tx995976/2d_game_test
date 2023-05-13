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

		if(ctrlnode.eventInput_action is null)
			SetProcessUnhandledInput(false);
		
		if(ctrlnode.veldirInput_action is null)
			SetPhysicsProcess(false);

		// if(ctrlnode is Iwalkable walkable)
		// 	walkSource = walkable;
		// else{
		// 	SetPhysicsProcess(false);
		// 	walkSource = null;
		// }

#if DEBUG
		logLine.info("sprite",
		$"""
			controll {((Node)ctrlnode)}
					velocity input: {(ctrlnode.veldirInput_action == null ? false : true)}
					view input: {(ctrlnode.viewInput_action == null ? false : true)}
		""");
#endif

	}


	public override void _PhysicsProcess(double delta) {
		var veldir = Input.GetVector("action_left", "action_right", "action_up", "action_down");
		// walkSource!.velocity_dir = veldir;

		ctrlSource!.veldirInput_action!.Invoke(veldir);

		//issue: view_dir?
	}

	public override void _UnhandledInput(InputEvent @event) {
		ctrlSource!.eventInput_action!.Invoke(@event);
		// GD.Print($"input {@event}");
	}


}
