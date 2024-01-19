using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Transform CubeRobotTransform;
    public Vector3 lastPosition;
    public float SpeedMove;
    bool hasMoved;
    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            Debug.Log("VICTORy");
        }
        if (hasMoved)
            CubeRobotTransform.position = CubeRobotTransform.position + (transform.position - lastPosition) * SpeedMove;
        else
            hasMoved = lastPosition != transform.position;
        lastPosition = transform.position;
    }
}
