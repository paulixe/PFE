using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AlertCanvas : MonoBehaviour
{
    public Text Text;
    public GameObject ContentHolder;
    float distanceFromCameraCanvas = 1.5f;
    [ContextMenu("test")]
    public void StandInFrontOfCamera()
    {
        Camera mainCamera = Camera.main;
        transform.position = mainCamera.transform.position + mainCamera.transform.forward * distanceFromCameraCanvas;
        transform.LookAt(mainCamera.transform.position, mainCamera.transform.up);

    }
    [ContextMenu("test2")]
    public void test2()
    {
        transform.Rotate(transform.up * 180f);
    }
}
