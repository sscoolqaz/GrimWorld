using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour {

    public Room currentRoom;


    Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();
    GameController controller;

    private void Awake()
    {
        controller = GetComponent<GameController> ();
    }

    //Goes over array of the exits in the game
    public void UnpackExitsInRoom()
    {
        //just entered room we're going to unpack the exits and show them on the screen
        for (int i = 0; i < currentRoom.exits.Length; i++)
        {
            //Sets the key then the value.
            exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueRoom);
            controller.interactionDescriptionsInRoom.Add(currentRoom.exits[i].exitDescription);

        }
    }


    //IMPORTANT Dictionaries cannot be serialized!!
    public void AttemptToChangeRooms(string directionNoun)
    {
        //checks if the dictionary has the keyword in it
        if (exitDictionary.ContainsKey (directionNoun))
        {
            
            //sets current room to exitDictionary
            currentRoom = exitDictionary[directionNoun];
            //Report back to game controller
            controller.LogStringWithReturn("You head off to the " + directionNoun);
            controller.DisplayLoggedText();

        } else
        {
            //If you cant go that direction display text + direction
            controller.LogStringWithReturn("There is no way to go " + directionNoun);
        }
    }

    public void ClearExits()
    {
        exitDictionary.Clear();
    }

}
