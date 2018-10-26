using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creates an asset menu
[CreateAssetMenu (menuName = "TextAdventure/Interactable Object")]
//Makes it scriptable
public class InteractableObject : ScriptableObject
{
    //creates variables for object
    public string noun = "name";
    
    //allows for a bigger text box for typing
    [TextArea]
    public string description = "Description in room";

    //collection of interactable objects
    public Interaction[] interactions;

}
