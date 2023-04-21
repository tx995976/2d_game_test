namespace Obj.util;

public class objectPool<T> where T : class, new()
{
	protected const int default_size = 20;

	protected Queue<T> pools;
	protected int length;

	/// (T,pool.push())
	public Action<T, Action<T>>? initAction;

	public Action<T>? pushAction;
	public Action<T>? getAction;


	#region init

	public objectPool(Action<T, Action<T>>? action = null, int size = default_size) {
		pools = new Queue<T>(size);
		initAction = action;
		length = size;
		init(size);
	}

	#endregion

	#region management

	virtual protected T init_instance() {
		var instance = new T();
		initAction?.Invoke(instance, push);
		return instance;
	}

	virtual protected T shortageAction() {
		return init_instance();
	}

	virtual protected void release(int len) {
		for (int i = 0;i < len;i++)
			pools.Dequeue();
	}

	protected void init(int len) {
		for (int i = 0;i < len;i++)
			pools.Enqueue(init_instance());
	}

	#endregion


	#region actions

	public void push(T obj) {
		pushAction?.Invoke(obj);
		pools.Enqueue(obj);
	}

	public T get() {
		var obj = pools.Count == 0 ? shortageAction() : pools.Dequeue();
		getAction?.Invoke(obj);
		return obj;
	}

	public void resize(int size) {
		if (pools.Count < size)
		{
			init(size - pools.Count);
		}
		else if (pools.Count > size)
		{
			release(pools.Count - size);
		}
	}

	#endregion


}