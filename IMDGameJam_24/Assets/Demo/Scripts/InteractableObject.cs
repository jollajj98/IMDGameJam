using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
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

    [Serializable]
    public class CustomEvent : UnityEvent { }
    [SerializeField]
    private CustomEvent customEvent = new CustomEvent();

    [SerializeField]
    Material interactMaterial;
    Material defaultMat;

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
            defaultMat =renderer.material;
    }
    public void TriggerEvent()
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

        customEvent.Invoke();
    }

    public void Select(bool enable)
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            if (enable)
            renderer.material = interactMaterial;
             else
                renderer.material = defaultMat;
        }
    }
}
