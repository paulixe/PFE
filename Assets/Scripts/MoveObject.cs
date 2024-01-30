using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Transform CubeRobotTransform;
    public Vector3 lastPosition;
    public float SpeedMove;
    bool hasMoved;
    bool isMoveModeOn;
    // Update is called once per frame
    void Update()
    {
        isMoveModeOn = OVRInput.Get(OVRInput.RawButton.RIndexTrigger);

        if (hasMoved&& isMoveModeOn)
            CubeRobotTransform.position = CubeRobotTransform.position + (transform.position - lastPosition) * SpeedMove;
        else
            hasMoved = lastPosition != transform.position;
        lastPosition = transform.position;
    }
}
