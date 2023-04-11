using System.Collections.Generic;
namespace Obj.util;

/// 普通下推状态机
public partial class stateNodeMachine :Node, IstateNodeMachine
{
	public bool is_active { get; set; } = true;

	public IstateNode? state_now { get; set; }

	[Export(PropertyHint.NodeType)]
	public Node? state_default { get; set; }
	
	public event Action<string>? state_changed;

	public Dictionary<string, IstateNode> state_list = new();
	public Stack<IstateNode> state_stack = new();

	public void change_state(StringName state,stc_mode mode = stc_mode.st_swap) {
		if (!is_active)
			return;
		
		state_now?.exit_state();
		switch (mode) {
			case stc_mode.st_push:
				state_stack.Push(state_now!);
				state_now = state_list[state!];
				break;
			case stc_mode.st_swap:
				state_now = state_list[state!];
				break;
			case stc_mode.st_ret:
				state_now = state_stack.Pop();
				break;
		}

		state_changed?.Invoke(state);
		state_now?.enter_state();

#if DEBUG
		logLine.debug("util",$"change state to {state_now?.name}");
#endif
	}

	public override void _Ready(){
		var states = GetChildren();
		foreach (IstateNode state in states){
			state_list[state.name!] = state;
			state.change_state += change_state;
		}

		state_now = (IstateNode)state_default!;
		state_now?.enter_state();
		logLine.debug("util",$"enter state {state_now?.name}");
	}
	
}
