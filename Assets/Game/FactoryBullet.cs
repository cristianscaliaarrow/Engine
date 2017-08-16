using UnityEngine;

public class FactoryBullet : SingletonClass<FactoryBullet>, ObjectPool<Bullet>.IFactory
{
    public Bullet prefab;
    public int initialStock;
    ObjectPool<Bullet> pool;

    public override void Awake()
    {
        base.Awake();
        pool = new ObjectPool<Bullet>(initialStock, this, true);
    }

    public Bullet CraeteMethod()
    {
        Bullet b = Instantiate(prefab);
        b.transform.SetParent(transform);
        return b;
    }

    public void DisableMethod(Bullet obj)
    {
        obj.gameObject.SetActive(false);
    }

    public void EnabledMethod(Bullet obj)
    {
        obj.gameObject.SetActive(true);
    }
}
