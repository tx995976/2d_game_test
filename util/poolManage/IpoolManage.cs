namespace Obj.util;

// 整个 class 由 pool 管理
public interface IpoolManage<T> : IpoolDispose
	where T : class, new()
{
	static objectPool<T> pool { get; } = new();
	abstract static T get();

}

public interface IpoolDispose
{
	void enPool();
}