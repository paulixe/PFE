using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform PlaneToLookAt;
    private void Update()
    {
        transform.LookAt(PlaneToLookAt.position);
    }
}
