
namespace Obj.autoload;

public interface IserviceCenter
{
    public void start_service();
    public void stop_service();

}

public interface IitemCenter : IserviceCenter
{
    //TODO: 负责物品管理

}


public interface IsoundCenter : IserviceCenter
{
    //TODO: 负责音乐

}

public interface IuiCenter : IserviceCenter
{
    //TODO: 负责暂停ui

}

public interface IhudCenter : IserviceCenter
{
    //TODO: 负责游戏内hud

}

public interface ImapCenter : IserviceCenter
{
    //TODO: 负责场景加载,切换,管理
}

public interface IeventCenter : IserviceCenter
{
    //TODO: 负责事件搜集,事件队列处理


}

public interface IeffectCenter : IserviceCenter
{
    //TODO: 负责效果应用(e.g. 加速,减速)
}


