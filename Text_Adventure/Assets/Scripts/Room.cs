using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Room")]
public class Room : ScriptableObject
{

    [TextArea]
    public string description;
    public string roomName;
    //array of exits
    public Exit[] exits;

    //creates an array of objects that you can interact with
    public InteractableObject[] interactableObjectsInRoom;

}
