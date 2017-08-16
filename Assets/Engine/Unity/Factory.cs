using UnityEngine;

public class Factory<T> : SingletonClass<Factory<T>> , IFactory where T:MonoBehaviour
{
    public T prefab;
    public ObjectPool<T> bullets;

    public virtual void Start()
    {
        bullets = new ObjectPool<T>(10,CreatheMethod, DisableMethod, true);
    }

    public T GetBullet()
    {
        T obj = bullets.GetObject();
        EnableMethod(obj);
        return obj;
    }

    public void ReturnBullet(T obj)
    {
        bullets.ReturnObject(obj);
        DisableMethod(obj);
    }

    void DisableMethod(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    void EnableMethod(T obj)
    {
        obj.gameObject.SetActive(true);
    }

    T CreatheMethod()
    {
        T obj = Instantiate(prefab);
        obj.transform.SetParent(instance.transform);
        return obj;
    }

    

}

