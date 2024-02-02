using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    [SerializeField]
    float boundaryScale = 10f;
    [SerializeField]
    Color boundaryColor = Color.blue;
    [SerializeField]
    AnimationCurve alphaCurve;

    [Header("Robot cube controller to set boundary center")]
    [SerializeField]
    GameObject CubeController;

    Vector3 boundaryCenter;
    MeshRenderer bRenderer;
    Vector3 initialCubePosition;

    float boundaryRadius => boundaryScale / 2;
    void Start()
    {
        transform.localScale = Vector3.one * boundaryScale;
        bRenderer = GetComponent<MeshRenderer>();
        boundaryCenter = CubeController.transform.position;
        initialCubePosition = CubeController.transform.position;
    }
    private void Update()
    {
        //float normalizedDistance = Mathf.Clamp01((CubeController.transform.position - boundaryCenter).magnitude / boundaryRadius);
        float normalizedDistance = (CubeController.transform.position - boundaryCenter).magnitude / boundaryRadius;
        if (normalizedDistance>1.5)
        {
            CubeController.transform.position = initialCubePosition;
            normalizedDistance = (CubeController.transform.position - boundaryCenter).magnitude / boundaryRadius;
        }
        float alpha = alphaCurve.Evaluate(normalizedDistance);
        bRenderer.material.color = new Color(boundaryColor.r, boundaryColor.g, boundaryColor.b, alpha);
    }


}
