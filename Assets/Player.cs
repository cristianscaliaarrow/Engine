using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    ObjectPool<int> integers;
    static int i;
	void Start () {
        integers = new ObjectPool<int>(5, ci, di, true);
        integers.GetObject();
	}

    private void di(int obj)
    {
        print("Store : " + obj);
    }

    private void ei(int obj)
    {
        print(obj);
    }

    private int ci()
    {
        return i++;
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(DestroyMe(FactoryBullet.instance.GetBullet()));
        }	
	}

    private IEnumerator DestroyMe(Bullet b)
    {
        yield return new WaitForSeconds(3);
        FactoryBullet.instance.ReturnBullet(b);
    }
}
