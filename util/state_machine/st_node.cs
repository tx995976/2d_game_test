namespace Obj.util;

public enum stc_mode :int
{
	st_push,
	st_swap,
	st_ret,
}

public interface IstateMachine
{
    public bool is_active { get; set; }

    IstateNode? state_now { get; set; }
    IstateNode? state_default { get; set; }

    
    public event Action<string>? state_changed;

    public void change_state(string state,stc_mode mode = stc_mode.st_swap);
}


public interface IstateNode
{
    // get => Node.Name;
    public string? name { get;}

    public void enter_state();
    public void exit_state();

    public void action_input(InputEvent @event){}

    public event Action<string,stc_mode>? change_state;

}

