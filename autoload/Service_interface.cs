using Obj.map;
namespace Obj.autoload;

public interface IserviceCenter
{
	public void start_service();
	public void stop_service();

}


public interface IitemCenter : IserviceCenter
{
	//: 负责物品管理
	

}


public interface IsoundCenter : IserviceCenter
{
	//: 负责音乐

}

public interface IuiCenter : IserviceCenter
{
	//: 负责暂停ui

}

public interface IhudCenter : IserviceCenter
{
	//: 负责游戏内hud


}

public interface ImapCenter : IserviceCenter
{
	//: 负责场景加载,切换,管理



}

public interface IeventCenter : IserviceCenter
{
	//: 负责事件搜集,事件队列处理


}

public interface IeffectCenter : IserviceCenter
{
	//: 负责效果应用(e.g. 加速,减速)
}


