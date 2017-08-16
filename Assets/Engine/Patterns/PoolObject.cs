using System;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool<T>  {

    public interface IFactory
    {
        T CraeteMethod();
        void EnabledMethod(T obj);
        void DisableMethod(T obj);
    }

    private IFactory _factory;
    private bool _dynamic;

    private LinkedList<T> _objects;

    public ObjectPool(int initialStock, IFactory factory,bool dynamic)
    {
        _factory = factory;
        _dynamic = dynamic;
        _objects = new LinkedList<T>();
        for (int i = 0; i < initialStock; i++)
            CreateObj();
    }

    private void CreateObj()
    {
        T obj = _factory.CraeteMethod();
        _objects.AddLast(obj);
        _factory.DisableMethod(obj);
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
