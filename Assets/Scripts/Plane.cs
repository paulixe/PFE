using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour, IIdentifiable
{
    public string TargetCubeId;



    [HideInInspector]
    public bool HasRightCubeOnIt = false;

    MeshRenderer meshRenderer;
    Material activatedMaterial;
    Material unactivatedMaterial;

    Vector3 unactivatedPosition;
    Vector3 activatedPosition => unactivatedPosition + Vector3.down * transform.localScale.y * 0.25f;

    public string GetId() => "Plane for " + TargetCubeId;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        activatedMaterial = meshRenderer.material;
        unactivatedPosition = transform.position;

        unactivatedMaterial = new Material(activatedMaterial);
        unactivatedMaterial.color = unactivatedMaterial.color * Settings.DarkeningFactor;
        RefreshVisual();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (IsTargetCube(collider))
        {
            HasRightCubeOnIt = true;
            RefreshVisual();
        }
    }
    private void OnTriggerStay(Collider collider)
    {
        if (IsTargetCube(collider))
        {
            HasRightCubeOnIt = true;
            RefreshVisual();
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (IsTargetCube(collider))
        {
            HasRightCubeOnIt = false;
            RefreshVisual();
        }
    }
    private void RefreshVisual()
    {
        if (HasRightCubeOnIt)
        {
            meshRenderer.material = activatedMaterial;
            transform.position = activatedPosition;
        }
        else
        {
            transform.position = unactivatedPosition;

            meshRenderer.material = unactivatedMaterial;
        }

    }
    private bool IsTargetCube(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<Cube>(out Cube cube))
        {
            return cube.GetId() == TargetCubeId;
        }
        return false;
    }
}
