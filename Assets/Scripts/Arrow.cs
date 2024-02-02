using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform PlaneToLookAt;
    public Material RightCubeToPlaceMaterial;
    private Material defaultMaterial;
    private MeshRenderer[] meshRenderers;

    private void Awake()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        defaultMaterial = meshRenderers[0].material;
    }

    public void SetOn()
    {
        foreach(var meshRenderer in meshRenderers)
        {
            meshRenderer.material = RightCubeToPlaceMaterial;
        }

    }
    public void SetOff()
    {
        foreach (var meshRenderer in meshRenderers)
        {
            meshRenderer.material = defaultMaterial;
        }
    }
        private void Update()
    {
        transform.position = transform.parent.transform.position + transform.parent.lossyScale.y*Vector3.up;
        transform.LookAt(PlaneToLookAt.position);
    }
}
