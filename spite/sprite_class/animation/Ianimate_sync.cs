using Obj.sp_player;

namespace Obj.util;

///标准状态与动画树同步
public interface IanimateTreeSync
{
    Istatemut? stateSource { get; set; }
    Resource? animationBlend { get; set; }

    public void motionStateChanged(string state);
    public void equipStateChanged(string state);

    //issue: 重新设计,使用actionInfo来同步动画
    
    ///一个造成动画变化,结束后能回到基本状态的转换为Action(eg. 开火)
    public void actionOccurred(string action);

    public void Travel(string state){}
}

///简易动画与数值同步
public interface IanimatePlayerSync
{
    public void motionParamChanged();

    public void Travel(string state){}
}
