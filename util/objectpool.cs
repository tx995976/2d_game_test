using Godot;
using System.Collections.Generic;
using System;

namespace Obj.util;

public class Objectpools<T> where T : class, new(){
  
    Queue<T> pools;
    Action<T>? initAction;

    PackedScene? tres;
    int size;

    #region init
    Objectpools(int size){
        pools = new Queue<T>(size);
        init();
    }

    Objectpools(int size,PackedScene tscn){
        pools = new Queue<T>(size);
        tres = tscn;
        init();
    }

    Objectpools(int size,PackedScene tscn,Action<T> action){
        pools = new Queue<T>(size);
        tres = tscn;
        initAction = action;
        init();
    }

    T init_instance(){
        var instance = tres?.Instantiate<T>() ?? new T();
        initAction?.Invoke(instance);
        return instance;
    }

    void init(){
        for(int i = 0; i < size; i++)
            pools.Enqueue(init_instance());
    }

    #endregion

    #region actions
    
    void push(T obj){
        pools.Enqueue(obj);
    }

    T pop(){
        if(pools.Count == 0)
            return init_instance();
        return pools.Dequeue();
    }

    #endregion

}