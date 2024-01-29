using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Plane> Planes;
    public AlertCanvas AlertCanvas;
    bool wonGame = false;


    void Update()
    {
        if (!wonGame & Planes.Count((p) => p.HasRightCubeOnIt) == Planes.Count)
        {

            AlertCanvas.ContentHolder.SetActive(true);
            AlertCanvas.Text.text = "Vous avez gagné";
            AlertCanvas.StandInFrontOfCamera();

            wonGame = true;
        }
    }
}
