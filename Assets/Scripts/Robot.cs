using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Robot : MonoBehaviour
{
    public LayerMask InteractableLayer;
    public GameObject TooltipCanvas;
    public Text TooltipText;

    private FixedJoint joint;
    private Interactable interactableInContact;
    private bool isGrabbing = false;
    private void Awake()
    {
        joint = GetComponent<FixedJoint>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)|| OVRInput.GetDown(OVRInput.RawButton.A))
        {
            if (isGrabbing)
                Ungrab();
            else
                Grab();
        }
    }
    private void RefreshTooltipState()
    {
        TooltipCanvas.SetActive(interactableInContact != null);

        if (isGrabbing)
        {
            TooltipText.text = "Press A to ungrab";
        }
        else
        {
            TooltipText.text = "Press A to grab";

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
            RefreshTooltipState();
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
            RefreshTooltipState();
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
            RefreshTooltipState();
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
