using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Exit
{
    //keyword for movement ie north south etc.
    public string keyString;

    //Displayed in action log
    public string exitDescription;

    //To be used in the dictionary
    public Room valueRoom;
}