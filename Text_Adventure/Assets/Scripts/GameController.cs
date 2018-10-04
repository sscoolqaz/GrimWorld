using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


       [HideInInspector] RoomNavigation roomNavigation
	// Use this for initialization
	void Awake () {
        roomNavigation = GetComponent<RoomNavigation>();
	}
	
    public void DisplayRoomText()
    {
        string combineText = roomNavigation.currentRoom.description + "/n";
    }


	// Update is called once per frame
	void Update () {
		
	}
}
