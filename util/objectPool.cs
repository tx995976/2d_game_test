namespace Obj.util;

public class objectPool<T> where T : class, new()
{

	const int default_size = 20;

	Queue<T> pools;

	public Action<T>? initAction;
	public Action<T>? pushAction;
	public Action<T>? getAction;

	int size;

	#region init

	public objectPool(int size = default_size) {
		pools = new Queue<T>(size);
		init();
	}

	public objectPool(Action<T> action, int size = default_size) {
		pools = new Queue<T>(size);
		initAction = action;
		init();
	}

	virtual public T init_instance() {
		var instance = new T();
		initAction?.Invoke(instance);
		return instance;
	}

	virtual public T shortageAction() {
		return init_instance();
	}

	public void init() {
		for (int i = 0;i < size;i++)
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
	#endregion


}