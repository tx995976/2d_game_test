using System.Collections.Generic;
namespace Obj.util;

/// 简易状态机实现
public partial class stateMachineSilm :Node, IstateMachine
{
	public bool is_active { get; set; }
	public IstateNode? state_now { get; set; }

	[Export]
	public Node? state_default { get; set; }

	public Dictionary<StringName, IstateNode> state_list = new();

	public event Action<string>? state_changed;

	public void change_state(StringName? state, stc_mode mode = stc_mode.st_swap) {
		if (!is_active || state is null)
			return;

		state_now = state_list[state];
		state_now?.exit_state();

		state_changed?.Invoke(state);
		state_now?.enter_state();
	}

	public override void _Ready(){
		var states = GetChildren();
		foreach (IstateNode state in states){
			state_list[state.name!] = state;
			state.change_state += change_state;
		}

		state_now = (IstateNode)state_default!;
		state_now?.enter_state();
	}
}
