using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        // Trouver la caméra principale
        mainCamera = Camera.main;
    }//

    private void Update()
    {
        // Vérifier si la caméra est définie
        if (mainCamera != null)
        {
            // Orienter le label vers la caméra
            transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
                             mainCamera.transform.rotation * Vector3.up);
        }
    }
}
