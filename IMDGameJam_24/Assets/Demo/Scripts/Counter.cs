using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Counter : MonoBehaviour
{
    int count;
    [SerializeField]
    int startValue;

    [Serializable]
    struct OnValueEvent
    {
        public int value;
        public CounterEvent counterEvent;
    }

    [SerializeField]
    OnValueEvent[] onReachedValueEvents;

    Dictionary<int, CounterEvent> eventsDict;

    private void Awake()
    {
        count = startValue;
        eventsDict = new Dictionary<int, CounterEvent>();
        foreach(OnValueEvent ev in  onReachedValueEvents)
        {
            if (!eventsDict.ContainsKey(ev.value))
            {
                eventsDict.Add(ev.value, ev.counterEvent);
            }
        }
    }

    public void Increment()
    {
        count++;
        if (eventsDict.ContainsKey(count))
        {
            eventsDict[count].TriggerEvent();
        }
    }

    public void Decrement()
    {
        count--;
        Debug.Log(count);
        if (eventsDict.ContainsKey(count))
        {
            eventsDict[count].TriggerEvent();
        }
    }

    public void Reset()
    {
        count = startValue;    }

}
