using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Raycast : MonoBehaviour
{

    [SerializeField]
    LayerMask layerMask;
    [SerializeField]
    InputAction playerInput;
    [SerializeField]
    Transform fromRaycast;
    InteractableObject currentInteractable;
    [SerializeField]
    float maxDistance = 5f;

    private void OnEnable()
    {
        playerInput.performed += PerformedInput;
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.performed -= PerformedInput;
        playerInput.Disable();
    }

    void PerformedInput(InputAction.CallbackContext ctx)
    {
        if (currentInteractable != null)
        {
            currentInteractable.TriggerEvent();
        }
    }

    void FixedUpdate()
    {


        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(fromRaycast.position, fromRaycast.TransformDirection(Vector3.forward), out hit, maxDistance, layerMask))
        {
            Debug.DrawRay(fromRaycast.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            currentInteractable = hit.transform.GetComponent<InteractableObject>();
            if (currentInteractable)
            {
                currentInteractable.Select(true);
            }
        }
        else
        {
            if (currentInteractable)
            {
                currentInteractable.Select(false);
            }
            currentInteractable = null;
            Debug.DrawRay(fromRaycast.position, fromRaycast.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
}

