namespace Obj.util;

public interface IstateActionNode{
    public string name { get; }

	public void enter_state();
	public void exit_state();

	public void action_input(InputEvent @event) { }

    public void _Ready();
    public void _PhysicsProcess(double delta);
    

	public event Action<StringName, stc_mode>? change_state;
}