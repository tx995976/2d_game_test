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

	string _shortcut_cache = string.Empty;
	StringBuilder _shortcut_builder = new("");

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
		_shortcut_cache = string.Empty;

		actionName = name;
		action.Invoke();

		stateChanged?.Invoke();
	}

	public string _shortcut() {
		if (_shortcut_cache != string.Empty)
			return _shortcut_cache;

		_shortcut_builder.Append(motionName);

		if (equipStateName != string.Empty){
			_shortcut_builder.Append('_');
			_shortcut_builder.Append(equipStateName);
		}

		if (equipStyleName != string.Empty){
			_shortcut_builder.Append('_');
			_shortcut_builder.Append(equipStyleName);
		}

		if (actionName != string.Empty){
			_shortcut_builder.Append('_');
			_shortcut_builder.Append(actionName);
		}

		_shortcut_cache = _shortcut_builder.ToString();
		_shortcut_builder.Clear();
		
		return _shortcut_cache;
	}

	#region Properties changed

	void motion_changed(string name) {
		_shortcut_cache = string.Empty;

		motionName = name;
		stateChanged?.Invoke();
	}

	void equip_state_changed(string name) {
		_shortcut_cache = string.Empty;

		//issue 此处转换"none" 到 null
		if (name != _none_str)
			equipStateName = name;
		else
			equipStateName = "";


		stateChanged?.Invoke();
	}

	void equip_changed() {
		_shortcut_cache = string.Empty;

		equipStyleName = equipSource!.bagNode!.selected_equip?.define?.itemStyle ?? "";
		stateChanged?.Invoke();
	}

	#endregion

}