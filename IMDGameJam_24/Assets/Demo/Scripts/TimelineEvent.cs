using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class TimelineEvent : MonoBehaviour
{
    [Serializable]
    public struct AnimatorEvent
    {
        [SerializeField]
        public Animator animator;
        [SerializeField]
        public string triggerName;
    }

    [SerializeField]
    AnimatorEvent[] animatorEvents;
    [SerializeField]
     GameObject[] activateObjects;
    [SerializeField]
     GameObject[] deactivateObjects;
    [SerializeField]
    AudioSource[] audioSources;

    Timeline _timeline;

    [Serializable]
    public class CustomTimelineEvent : UnityEvent { }
    [SerializeField]
    private CustomTimelineEvent customTimelineEvent = new CustomTimelineEvent();
  
  

    public void InitialiseEvent(Timeline timeline)
    {


        _timeline = timeline;
        TriggerEvent();
        
    }

    void TriggerEvent()
    {
        foreach (AnimatorEvent anim in animatorEvents)
        {
            if (anim.animator != null)
                anim.animator.SetTrigger(anim.triggerName);
        }

        foreach (AudioSource audio in audioSources)
        {
            if (audio != null)
                audio.Play();
        }

        foreach (GameObject obj in activateObjects)
        {
            if (obj != null)
                obj.SetActive(true);
        }
        foreach (GameObject obj in deactivateObjects)
        {
            if (obj != null)
                obj.SetActive(false);
        }

        customTimelineEvent.Invoke();

        _timeline.Next();
        
    }


}
