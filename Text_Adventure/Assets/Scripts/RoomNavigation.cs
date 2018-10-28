using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour {

	public Room currentRoom;


	Dictionary<string, Room> exitDictionary = new Dictionary<string, Room> ();
	GameController controller;

	void Awake()
	{
		controller = GetComponent<GameController> ();
	}

    //Goes over array of exits in the game
	public void UnpackExitsInRoom()
	{
        //for the entered we need to unpack and display the new exits.
		for (int i = 0; i < currentRoom.exits.Length; i++) 
		{
            //sets the key then the value
			exitDictionary.Add (currentRoom.exits [i].keyString, currentRoom.exits [i].valueRoom);
			controller.interactionDescriptionsInRoom.Add (currentRoom.exits [i].exitDescription);
		}
	}

    //IMPORTANT Dictionaries cannot be serialized
	public void AttemptToChangeRooms(string directionNoun)
	{
        //checks if the dictionary has the keyword in it
		if (exitDictionary.ContainsKey (directionNoun))
        {
			currentRoom = exitDictionary [directionNoun];
			controller.LogStringWithReturn ("You head off to the " + directionNoun);
			controller.DisplayRoomText ();
		} else 
		{
			controller.LogStringWithReturn ("There is no path to the " + directionNoun);
		}

	}

	public void ClearExits()
	{
		exitDictionary.Clear ();
	}
}
