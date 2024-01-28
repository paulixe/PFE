using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Material GrabbedMaterial;
    [Range(0, 1)]
    [Tooltip("Factor used for the canDriectlyInteractMaterial, it darkens the defaultMaterial")]
    public float InteractableDarkenFactor = 0.8f;

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
        canDirectlyInteractMaterial.color = canDirectlyInteractMaterial.color * InteractableDarkenFactor;
    }
    void RefreshVisual()
    {
        var mats = new List<Material>() { };
        if (isOn)
            mats.Add(canDirectlyInteractMaterial);
        else
            mats.Add(defaultMaterial);

        if (isGrabbed)
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
