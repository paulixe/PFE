using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AlertCanvas : MonoBehaviour
{
    public Text Text;
    public GameObject ContentHolder;
    float distanceFromCameraCanvas = 1.5f;
    public void StandInFrontOfCamera()
    {
        Camera mainCamera = Camera.main;
        transform.position = mainCamera.transform.position + mainCamera.transform.forward * distanceFromCameraCanvas;
        //transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward, mainCamera.transform.rotation * Vector3.up);

    }
}
