using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class OnTriggerEvent : MonoBehaviour
{
    [SerializeField]
    bool triggerOnlyOnce;

    [SerializeField]
    string triggerColliderTag;


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

    [Serializable]
    public class CustomEvent : UnityEvent { }
    [SerializeField]
    private CustomEvent customEvent = new CustomEvent();

    bool triggered;

    private void OnTriggerEnter(Collider other)
    {

        if (triggered && triggerOnlyOnce)
            return;
        if (!other.CompareTag(triggerColliderTag))
            return;

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

        customEvent.Invoke();
        triggered = true;
   
    }
}
