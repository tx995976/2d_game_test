namespace Obj.sp_player.status;

public partial class state_equip_aim : Node, IstateNode
{
	public string name => "aim";

	public event Action<StringName, stc_mode>? change_state;

	Iwalkable? _walkSource;
	Node2D? _2dSource;
	Icontrollable? _controllSource;
	Iequiphave? _bagSource;

	public override void _EnterTree() {
		_walkSource = (Iwalkable)Owner;
		_2dSource = (Node2D)Owner;
		_controllSource = (Icontrollable)Owner;
		_bagSource = (Iequiphave)Owner;
	}

	public override void _Ready() {
		SetPhysicsProcess(false);
	}

	public override void _PhysicsProcess(double delta) {
		_walkSource!.view_dir = _2dSource!.GetLocalMousePosition();

	}

	public void action_input(InputEvent @event) {
		if (@event.IsActionReleased("battle_weapon_ready"))
			change_state?.Invoke("none", stc_mode.st_swap);


	}

	public void enter_state() {
		_controllSource!.eventInput_action += action_input;
		SetPhysicsProcess(true);
	}

	public void exit_state() {
		_controllSource!.eventInput_action -= action_input;
		SetPhysicsProcess(false);
	}
}
