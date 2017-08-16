using UnityEngine;

public class FactoryBullet : Factory<Bullet>
{
    public override void DisableMethod(Bullet obj)
    {
        base.DisableMethod(obj);
        print("Factory Bullet - DisableMethod");
    }

    public override void EnabledMethod(Bullet obj)
    {
        base.EnabledMethod(obj);
        print("Factory Bullet - EnabledMethod");
    }
}
