using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timeline : MonoBehaviour
{
    [Serializable]
    public struct TimestampEvent
    {
        [SerializeField]
        public TimelineEvent timelineEvent;
        [SerializeField]
        public float waitTime;
    }

    int current = 0;
    bool triggeredNext = false;

    [SerializeField]
    TimestampEvent[] allEvents;



    private void Update()
    {
    
        if (!triggeredNext && current < allEvents.Length)
        {
            Invoke("InitialiseSignal", allEvents[current].waitTime); 
             triggeredNext = true;
           }

    }


    void InitialiseSignal()
    {
        allEvents[current].timelineEvent.InitialiseEvent(this);
   
    }

    public void Next()
    {
        current++;
        triggeredNext = false;
    }
}
