using System;
using UnityEngine;

public class Factory<T> : SingletonClass<Factory<T>>, ObjectPool<T>.IFactory where T:MonoBehaviour
{
    public T prefab;
    public int initialStock;
    ObjectPool<T> pool;

    static int i;
    public override void Awake()
    {
        base.Awake();
        pool = new ObjectPool<T>(initialStock, this, true);
    }

    public T CraeteMethod()
    {
        T b = Instantiate(prefab);
        b.name = ""+i++;
        b.transform.SetParent(transform);
        return b;
    }

    public virtual void DisableMethod(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    public virtual void EnabledMethod(T obj)
    {
        obj.gameObject.SetActive(true);
    }

    public static T Pool {
        get {
            T obj = instance.pool.GetObject();
            instance.EnabledMethod(obj);
            return obj;
        }
        set
        {
            instance.DisableMethod(value);
            instance.pool.ReturnObject(value);
        }
    }
}

