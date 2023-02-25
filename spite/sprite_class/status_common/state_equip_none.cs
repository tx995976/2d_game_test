namespace Obj.sp_player.status;

public partial class state_equip_none : Node, IstateNode
{
	public string? name => "none";

	public event Action<StringName, stc_mode>? change_state;

	public void enter_state()
	{
		
	}

	public void exit_state()
	{
		
	}
}
