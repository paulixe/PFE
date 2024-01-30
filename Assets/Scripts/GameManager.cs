using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    public AlertCanvas AlertCanvas;


    bool wonGame = false;

    public static  Action<Plane> PlanesActivated;
    public static  Action<Plane> PlanesOff;

    public List<Plane> WantedPlanesOnOrder;
    public List<Plane> planesOn;

    private void Awake()
    {
        PlanesActivated += (p) => AddPlaneOn(p);
        PlanesOff += (p) => planesOn.Remove(p);
    }
    void AddPlaneOn(Plane plane)
    {
        if (!planesOn.Contains(plane))
            planesOn.Add(plane);
    }
    void Update()
    {
        if (!wonGame&&planesOn.Count==WantedPlanesOnOrder.Count)
        {
            for(int i=0;i<planesOn.Count;i++)
            {
                if (planesOn[i] != WantedPlanesOnOrder[i])
                    return;
            }
            AlertCanvas.ContentHolder.SetActive(true);
            AlertCanvas.Text.text = "Vous avez gagné";
            AlertCanvas.StandInFrontOfCamera();
            wonGame = true;
        }
    }
}
