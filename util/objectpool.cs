using Godot;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Obj.util;

public class Objectpools<T> where T : class, new(){
  
	Queue<T> pools;
	Action<T>? initAction;

	PackedScene? tres;
	int size;

	#region init
	public Objectpools(int size){
		pools = new Queue<T>(size);
		init();
	}

	public Objectpools(int size,PackedScene tscn){
		pools = new Queue<T>(size);
		tres = tscn;
		init();
	}

	public Objectpools(int size,PackedScene tscn,Action<T> action){
		pools = new Queue<T>(size);
		tres = tscn;
		initAction = action;
		init();
	}

	public T init_instance(){
		var instance = tres?.Instantiate<T>() ?? new T();
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
		pools.Enqueue(obj);
	}

	public T pop() =>
		pools.Count == 0 ? init_instance() : pools.Dequeue();
		

	#endregion

}
