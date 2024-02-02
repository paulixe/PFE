using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject CubeRobot;
    public Vector3 lastPosition;
    public float SpeedMove;

    private Robot robot;
    bool hasMoved;
    bool isMoveModeOn;
    // Update is called once per frame
    private void Start()
    {
        robot = CubeRobot.GetComponent<Robot>();
        robot.ChangeTooltip("Press index trigger to move robot");
    }
    void Update()
    {
        isMoveModeOn = OVRInput.Get(OVRInput.RawButton.RIndexTrigger);

        if (isMoveModeOn)
        {
            if (hasMoved)
            {
                
                CubeRobot.transform.position = CubeRobot.transform.position + (transform.position - lastPosition) * SpeedMove;
            }
            else
            {
                hasMoved = lastPosition != transform.position;
                if (hasMoved)
                {
                    robot.ChangeTooltip("", false);
                }
            }
        }


        lastPosition = transform.position;
    }
}
