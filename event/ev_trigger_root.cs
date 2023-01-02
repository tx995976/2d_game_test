using Godot;
using static Godot.GD;

namespace Obj.ev_trigger;

public partial class ev_trigger_root : Area2D
{

    [Export(PropertyHint.Enum)]
	public tar_limit target_type = tar_limit.Once;

	public enum tar_limit{
		Once,
		Infinite
	}

    //处理player进入
    public virtual void sp_enter(Node2D body){}
    public virtual void sp_exit(Node2D body){}

    //处理状态恢复(重置)
    public virtual void st_reset(){}


}