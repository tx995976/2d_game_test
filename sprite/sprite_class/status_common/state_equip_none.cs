namespace Obj.sp_player.status;

public partial class state_equip_none : Node, IstateNode
{
	public string name => "none";

	public event Action<StringName, stc_mode>? change_state;

	Icontrollable? _controllSource;
	Iequiphave? _bagSource;

	public override void _EnterTree() {
		_controllSource = (Icontrollable)Owner;
		_bagSource = (Iequiphave)Owner;

	}

	public void action_input(InputEvent @event) {
		if (@event.IsActionPressed("battle_weapon_ready") && _bagSource!.bagNode!.selected_supply is not null)
		{
			change_state?.Invoke("aim", stc_mode.st_swap);
		}

		
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
