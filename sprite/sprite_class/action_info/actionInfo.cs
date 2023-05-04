using System.Text;

namespace Obj.sp_player;


public class actionInfo
{
	public static string _none_str = "none";

	public string motionName { get; set; } = string.Empty;

	public string equipStateName { get; set; } = string.Empty;

	public string equipStyleName { get; set; } = string.Empty;

	public string actionName { get; set; } = string.Empty;


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
		logLine.debug("sprite", $"""
			{this} , InfoSource:
							motion_state: {Source.motionState}
							equip_state: {Source.equipState}
							equipSource: {equipSource}
			""");
#endif
	}

	public void invoke_action(string name, Action action) {
		actionName = name;
		action.Invoke();

		stateChanged?.Invoke();
	}

	public string _shortcut() {
		var _actionState = new StringBuilder("");
		_actionState.Append(motionName);

		if (equipStateName != string.Empty)
			_actionState.Append('_' + equipStateName);

		if (equipStyleName != string.Empty)
			_actionState.Append('_' + equipStyleName);

		if (actionName != string.Empty)
			_actionState.Append('_' + actionName);

		return _actionState.ToString();
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