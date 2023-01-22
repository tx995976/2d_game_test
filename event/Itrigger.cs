
namespace Obj.ev_trigger;

public interface Itrigger : Ievent
{
	public enum trigger_limit{
		Once,
		Infinite
	};
	
	public trigger_limit target_type { get; set; }
	public event Action trigger_event;

	//trigger region
	public void sp_enter(Node2D body);
	public void sp_exit(Node2D body);

	
}