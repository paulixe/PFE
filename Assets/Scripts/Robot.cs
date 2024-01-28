using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public LayerMask InteractableLayer;

    private FixedJoint joint;
    private Interactable interactableInContact;
    private bool isGrabbing = false;
    private void Awake()
    {
        joint = GetComponent<FixedJoint>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrabbing)
                Ungrab();
            else
                Grab();
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (TryGetInteractable(collider, out Interactable interactable))
        {
            if (interactableInContact == null)
            {
                interactable.SetOn();
                interactableInContact = interactable;
            }
        }
    }
    private void OnTriggerStay(Collider collider)
    {
        if (TryGetInteractable(collider, out Interactable interactable))
        {
            if (interactableInContact == null)
            {
                interactable.SetOn();
                interactableInContact = interactable;
            }
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (TryGetInteractable(collider, out Interactable interactable))
        {
            if (interactableInContact == interactable)
            {
                interactable.SetOff();
                interactableInContact = null;
            }
        }
    }
    private bool TryGetInteractable(Collider collider, out Interactable interactable)
    {
        if ((InteractableLayer.value & 1 << collider.gameObject.layer) > 0)
            return collider.gameObject.TryGetComponent<Interactable>(out interactable);
        interactable = null;
        return false;
    }

    private void Grab()
    {
        if (interactableInContact != null)
        {
            joint.connectedBody = interactableInContact.Rigidbody;
            interactableInContact.Grabbed();
            isGrabbing = true;
            Debug.Log("grab");
        }
    }
    private void Ungrab()
    {
        if (interactableInContact != null)
        {
            Destroy(joint);
            joint = gameObject.AddComponent<FixedJoint>();
            interactableInContact.Ungrabbed();
        }
        Debug.Log("ungrab");
        isGrabbing = false;
    }
}
