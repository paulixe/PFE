using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public GameObject TargetCube;



    [HideInInspector]
    public bool HasRightCubeOnIt = false;

    MeshRenderer meshRenderer;
    Material activatedMaterial;
    Material unactivatedMaterial;

    Vector3 unactivatedPosition;
    Vector3 activatedPosition => unactivatedPosition + Vector3.down * transform.localScale.y * 0.25f;

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
            DetectedCube();
        }
    }
    private void OnTriggerStay(Collider collider)
    {
        if (IsTargetCube(collider))
        {
            DetectedCube();
        }
    }
    void DetectedCube()
    {
        HasRightCubeOnIt = true;
        RefreshVisual();
        GameManager.PlanesActivated?.Invoke(this);
    }
    private void OnTriggerExit(Collider collider)
    {
        if (IsTargetCube(collider))
        {
            HasRightCubeOnIt = false;
            RefreshVisual();
            GameManager.PlanesOff?.Invoke(this);
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
        return collider.gameObject == TargetCube;
    }
}
