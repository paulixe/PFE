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
        PlanesOff += (p) => RemovePlaneOn(p);
    }
    private void Start()
    {
        SetYellowArrow(0);
    }
    void AddPlaneOn(Plane plane)
    {
        if (!planesOn.Contains(plane))
        {
            planesOn.Add(plane);
            int count = planesOn.Count()-1;
            if (planesOn[count]!=WantedPlanesOnOrder[count])
            {
                planesOn[count].ChangeTooltip("Wrong order, the "+TranslateInteger(count)+" plane on should be "+WantedPlanesOnOrder[count].ColorExpected);
            }
            RefreshYellowArrow();
        }

    }
    void RefreshYellowArrow()
    {
        for(int i=0;i<WantedPlanesOnOrder.Count;i++)
        {
            if (planesOn.Count >i)
            {
                if (planesOn[i] != WantedPlanesOnOrder[i])
                {
                    SetYellowArrow(i);
                    return;
                }
            }
            else
            {
                SetYellowArrow(i);
                return;
            }

        }
    }
    void SetYellowArrow(int index)
    {
        for(int i=0;i<WantedPlanesOnOrder.Count;i++)
        {
            if (i != index)
                WantedPlanesOnOrder[i].TargetCube.GetComponentInChildren<Arrow>().SetOff();
            else
                WantedPlanesOnOrder[i].TargetCube.GetComponentInChildren<Arrow>().SetOn();
        }
    }
    string TranslateInteger(int order)
    {
        if (order == 0)
            return "first";
        else if (order == 1)
            return "second";
        else if (order == 2)
            return "third";
        else throw new Exception("shouldn't be possible in our case, there are only 3 cubes");
    }
    void RemovePlaneOn(Plane plane)
    {
        if (planesOn.Contains(plane))
        {
            int count = planesOn.Count() - 1;
            planesOn[count].ChangeTooltip("", false);
            planesOn.Remove(plane);
            RefreshYellowArrow();
        }
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
