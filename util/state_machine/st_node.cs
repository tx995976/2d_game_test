namespace Obj.util;

public enum stc_mode : int
{
	st_push,
	st_swap,
	st_ret,
}

public interface IstateNodeMachine
{
	public bool is_active { get; set; }
	public IstateNode? state_now { get; set; }
	public Node? state_default { get; set; } // need export

	public event Action<string>? state_changed;

	public void change_state(StringName state, stc_mode mode = stc_mode.st_swap);
}

public interface IstateActionMachine
{
	//TODO
	


}


public interface IstateNode
{
	// get => Node.Name;
	public string name { get; }

	public void enter_state();
	public void exit_state();

	public void action_input(InputEvent @event) { }

	public event Action<StringName, stc_mode>? change_state;

}

