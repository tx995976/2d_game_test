namespace Obj.sp_player;


public class actionInfo
{
	public static StringName _none_str = "none";

	public StringName motionName { get; set; } = string.Empty;

	public StringName equipStateName { get; set; } = string.Empty;

	public StringName equipStyleName { get; set; } = string.Empty;

	public StringName actionName { get; set; } = string.Empty;


	//required
	Istatemut Source { get; set; }
	Iequiphave? equipSource { get; set; }

	public event Action? stateChanged;

	public actionInfo(Istatemut owner) {
		Source = owner;
		equipSource = owner as Iequiphave;
	}

	public void _Ready() {
		if (Source.motionState is not null)
			Source.motionState.state_changed += motion_changed;

		if (Source.equipState is not null)
			Source.equipState.state_changed += equip_state_changed;

		if (equipSource is not null)
			equipSource.bagNode!.selected_changed += equip_changed;

#if DEBUG
		// GD.Print(this, " InfoSource:");
		// GD.Print($"""
		// 	motion_state: {Source.motionState}
		// 	equip_state: {Source.equipState}
		// 	equipSource: {equipSource}
		// 	""");

#endif
	}

	public void invoke_action(StringName name, Action action) {
		actionName = name;
		action.Invoke();

		stateChanged?.Invoke();
	}

	public StringName _shortcut() {
		var _actionState = "";
		_actionState = motionName;

		if (equipStateName != string.Empty)
			_actionState += '_' + equipStateName;

		if (equipStyleName != string.Empty)
			_actionState += '_' + equipStyleName;

		if (actionName != string.Empty)
			_actionState += '_' + actionName;

		return (StringName)_actionState;
	}

	#region Properties changed

	void motion_changed(string name) {
		motionName = name;
		stateChanged?.Invoke();
	}

	void equip_state_changed(string name) {
		//issue 此处转换"none" 到 null
		if (name != _none_str)
			equipStateName = name;
		else
			equipStateName = "";

		stateChanged?.Invoke();
	}

	void equip_changed() {
		equipStyleName = equipSource!.bagNode!.selected_equip?.define?.itemStyle ?? "";
		stateChanged?.Invoke();
	}

	#endregion

}