namespace Obj.sp_player;

///标准状态与动画树同步
public interface IanimateTreeSync
{
    Istatemut? stateSource { get; set; }
    Resource? animationBlend { get; set; }

    public void motionStateChanged(string state);
    public void equipStateChanged(string state);

    public void actionOccurred(string action);

    public void Travel(string state){}
}

public interface IanimateActionSync
{
    Iactor? stateSource { get; set; }
    res_animation_blend? animationBlend { get; set; }

    void actionStateChanged();

    public void Travel(string state);
}



///简易动画与数值同步
public interface IanimatePlayerSync
{
    public void motionParamChanged();

    public void Travel(string state){}
}
