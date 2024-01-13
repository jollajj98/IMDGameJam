using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.Events;

public class PlayerInputEvent : MonoBehaviour
{
    [SerializeField]
    InputAction playerInput;


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

    private void OnEnable()
    {
        playerInput.performed += TriggerEvent;
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.performed -= TriggerEvent;
        playerInput.Disable();
    }

    void TriggerEvent(InputAction.CallbackContext ctx)
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
}
