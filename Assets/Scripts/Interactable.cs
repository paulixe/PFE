using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Interactable : MonoBehaviour
{
    public Material GrabbedMaterial;

    [HideInInspector]
    public Rigidbody Rigidbody;
    MeshRenderer meshRenderer;
    Material defaultMaterial;
    Material canDirectlyInteractMaterial;

    bool isOn = false;
    bool isGrabbed = false;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        defaultMaterial = meshRenderer.material;
        canDirectlyInteractMaterial = new Material(defaultMaterial);
        canDirectlyInteractMaterial.color = canDirectlyInteractMaterial.color * Settings.DarkeningFactor;
    }
    void RefreshVisual()
    {
        var mats = new List<Material>() { };
        if (isOn)
            mats.Add(canDirectlyInteractMaterial);
        else
            mats.Add(defaultMaterial);

        if (isGrabbed&&GrabbedMaterial!=null)
            mats.Add(GrabbedMaterial);

        meshRenderer.SetMaterials(mats);
    }
    public void SetOn()
    {
        isOn = true;
        RefreshVisual();
    }
    public void SetOff()
    {
        isOn = false;
        RefreshVisual();
    }
    public void Grabbed()
    {
        isGrabbed = true;
        RefreshVisual();
    }
    public void Ungrabbed()
    {
        isGrabbed = false;
        RefreshVisual();
    }
}
