using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTranspChange : MonoBehaviour
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

    float boundaryRadius => boundaryScale / 2;
    void Start()
    {
        transform.localScale = Vector3.one * boundaryScale;
        bRenderer = GetComponent<MeshRenderer>();
        boundaryCenter = CubeController.transform.position;
    }
    private void Update()
    {
        float normalizedDistance = Mathf.Clamp01((CubeController.transform.position - boundaryCenter).magnitude / boundaryRadius);
        float alpha = alphaCurve.Evaluate(normalizedDistance);
        bRenderer.material.color = new Color(boundaryColor.r, boundaryColor.g, boundaryColor.b, alpha);
    }


}
