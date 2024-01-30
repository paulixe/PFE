using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        // Trouver la cam�ra principale
        mainCamera = Camera.main;
    }//

    private void Update()
    {
        // V�rifier si la cam�ra est d�finie
        if (mainCamera != null)
        {
            // Orienter le label vers la cam�ra
            transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
                             mainCamera.transform.rotation * Vector3.up);
        }
    }
}
