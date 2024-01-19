using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    Material defaultMaterial;
    public Material interactedWithMaterial;
    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        defaultMaterial = meshRenderer.material;
    }

    
    private void OnTriggerEnter(Collider collider)
    {

        if (collider.CompareTag("robot"))
        {
            meshRenderer.material = interactedWithMaterial;
        }
    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("robot"))
        {
            meshRenderer.material = interactedWithMaterial;
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("robot"))
        {
            meshRenderer.material = defaultMaterial;
        }
    }

}
