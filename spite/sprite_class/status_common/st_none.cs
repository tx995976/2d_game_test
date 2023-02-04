namespace Obj.sp_player.status;

public partial class state_none : Node, IstateNode
{
    public string? name => Name;

    public event Action<string, stc_mode>? change_state;

    public void enter_state()
    {
        
    }

    public void exit_state()
    {
        
    }
}