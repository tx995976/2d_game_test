using System.Collections.Generic;
namespace Obj.util;

/// 简易状态机实现
public class stateMachineSilm :Node, IstateMachine
{
	public bool is_active { get; set; }
	public IstateNode? state_now { get; set; }
	public IstateNode? state_default { get; set; }

	public Dictionary<string, IstateNode> state_list = new();

	public event Action<string>? state_changed;

	public void change_state(string state, int mode = 1) {
		if (!is_active)
			return;

		state_now = state_list[state];
		state_now?.exit_state();

		state_changed?.Invoke(state);
		state_now?.enter_state();
	}

	public override void _Ready(){
		var states = GetChildren();
		foreach (IstateNode state in states){
			state_list[state.name] = state;
			state.state_change += change_state;
		}

		state_now = state_default;
		state_now?.enter_state();
	}
}