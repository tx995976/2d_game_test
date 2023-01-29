using System.Collections.Generic;
namespace Obj.util;

/// 普通下推状态机
public class stateMachine :Node, IstateMachine
{
	public bool is_active { get; set; }

	public IstateNode? state_now { get; set; }
	public IstateNode? state_default { get; set; }

	public enum st_mode :int
	{
		st_push,
		st_swap,
		st_ret,
	}

	public event Action<string>? state_changed;

	public Dictionary<string, IstateNode> state_list = new();
	public Stack<IstateNode> state_stack = new();

	public void change_state(string state,int mode = 1) {
		if (!is_active)
			return;

		state_now?.exit_state();
		switch ((st_mode)mode) {
			case st_mode.st_push:
				state_stack.Push(state_now!);
				state_now = state_list[state];
				break;
			case st_mode.st_swap:
				state_now = state_list[state];
				break;
			case st_mode.st_ret:
				state_now = state_stack.Pop();
				break;
		}

		state_changed?.Invoke(state);
		state_now?.enter_state();

#if DEBUG
		GD.Print($"change state to {state_now?.name}");
#endif
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