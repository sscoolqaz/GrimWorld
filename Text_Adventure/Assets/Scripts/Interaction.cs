using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Interaction
{
    public InputAction inputAction;
    [TextArea]
    //if the object has a text response itll give it to you
    public string textResponse;
    //in most cases this would be null but since we are "using" the item it wont be
    public ActionResponse actionResponse;
}
