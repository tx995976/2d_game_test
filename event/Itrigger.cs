
namespace Obj.Event;

public interface Itrigger
{
	public enum trigger_limit{
		Once,
		Infinite
	};
	
	trigger_limit target_type { get; set; }
	bool Is_trigger { get; set; }

	public event Action trigger_event;


	//trigger region
	void sp_enter(Node2D body);
	void sp_exit(Node2D body);

	public void trigger_exec();

	public void trigger_reset(){
		Is_trigger = false;
	}
}