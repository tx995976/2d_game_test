namespace Obj.util;

public interface IstateParallelNode
{
	public string name { get; }
	public bool isActive { get; set; }

	public void active_state();
	public void inactive_state();

	public void condition_change();

	public void action_input(InputEvent @event) { }

	public void _Ready();
	public void _PhysicsProcess(double delta) { }
	public void _Process(double delta) { }
}