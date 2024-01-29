using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Interactable, IIdentifiable
{
    public string Id;

    public string GetId() => Id;
}
