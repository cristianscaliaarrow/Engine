using System;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool<T>  {

    public delegate T CallbackFactory();
    public delegate void PoolCallback(T obj);

    private CallbackFactory _factory;
    private PoolCallback _disableMethod;
    private bool _dynamic;

    private LinkedList<T> _objects;

    public ObjectPool(int initialStock,CallbackFactory factoryMethod,PoolCallback disableMethod,bool dynamic)
    {
        _factory = factoryMethod;
        _disableMethod = disableMethod;
        _dynamic = dynamic;
        _objects = new LinkedList<T>();
        for (int i = 0; i < initialStock; i++)
            CreateObj();
    }

    private void CreateObj()
    {
        T obj = _factory();
        _objects.AddLast(obj);
        _disableMethod(obj);
    }

    public T GetObject()
    {
        if (_objects.Count == 0 && _dynamic)
        {
            CreateObj();
        }
        
        if (_objects.Count > 0)
        {
            T obj = _objects.First.Value;
            _objects.RemoveFirst();
            return obj;
        }
        else
        {
            return default(T);
        }
    }

    public void ReturnObject(T obj)
    {
        _objects.AddLast(obj);
    }

}
