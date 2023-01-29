namespace Obj.util;

public interface IstateMachine
{
    public bool is_active { get; set; }

    IstateNode? state_now { get; set; }
    IstateNode? state_default { get; set; }

    public event Action<string>? state_changed;

    public void change_state(string state,int mode = 1);
}

public interface IstateNode
{
    // get => Node.Name;
    public string name { get; set; }

    public void enter_state();
    public void exit_state();

    public event Action<string,int>? state_change;

}

