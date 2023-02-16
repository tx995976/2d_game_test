using System.Buffers;

namespace Obj.util;

public class Nodepools<T> where T : Node, new(){

	const int default_size = 20;
  
	Queue<T> pools;

	Action<T>? initAction;
	public Action<T>? pushAction;  
	public Action<T>? getAction;

	PackedScene tres;
	int size;

	#region init

	public Nodepools(PackedScene tscn,int size = default_size){
		pools = new Queue<T>(size);
		tres = tscn;
		init();
	}

	public Nodepools(PackedScene tscn,Action<T> action,int size = default_size){
		pools = new Queue<T>(size);
		tres = tscn;
		initAction = action;
		init();
	}

	public T init_instance(){
		var instance = tres.Instantiate<T>();
		initAction?.Invoke(instance);
		return instance;
	}

	public void init(){
		for(int i = 0; i < size; i++)
			pools.Enqueue(init_instance());
	}

	#endregion

	#region actions
	
	public void push(T obj){
		pushAction?.Invoke(obj);
		pools.Enqueue(obj);
	}

	public T get(){
		var obj = pools.Count == 0 ? init_instance() : pools.Dequeue();
		getAction?.Invoke(obj);
		return obj;
	}
		
	#endregion

}
