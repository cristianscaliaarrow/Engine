using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private void Start()
    {
        EventManager.AddEventListener(EventsId.GameStart, OnStart);
        EventManager.AddEventListener(EventsId.GamePause, OnPausa);
        EventManager.AddEventListener(EventsId.GameEnd, OnEnd);
    }

    private void OnEnd()
    {
        print("OnEnd");
    }

    private void OnPausa()
    {
        print("OnPausa");
    }

    private void OnStart()
    {
        print("OnStart");
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Bullet b = FactoryBullet.Pool;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            EventManager.DispathEvent(EventsId.GameStart);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            EventManager.DispathEvent(EventsId.GamePause);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            EventManager.DispathEvent(EventsId.GameEnd);
        }
    }

   
}
