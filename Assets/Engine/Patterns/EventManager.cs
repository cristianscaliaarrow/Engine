using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager {
    public delegate void Event();

    public static Dictionary<int, Event> events = new Dictionary<int, Event>();

    public static void AddEventListener(int id,Event function)
    {
        if (events.ContainsKey(id))
            events[id] += function;
        else
            events.Add(id, function);
    }
	
    public static void DispathEvent(int id)
    {
        events[id]();
    }
}
