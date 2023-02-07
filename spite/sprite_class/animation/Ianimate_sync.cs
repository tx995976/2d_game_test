using Obj.sp_player;

namespace Obj.util;

///标准状态与动画树同步
public interface IanimateTreeSync
{
    Istatemut stateSource { get; set; }

    public void motionStateChanged();
    public void equipStateChanged();

}

///简易动画与数值同步
public interface IanimatePlayerSync
{

    public void motionParamChanged();

}
