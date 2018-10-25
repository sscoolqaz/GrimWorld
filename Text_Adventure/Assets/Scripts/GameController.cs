using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text displayText;
    //Array for the game to comapre input to
    public InputAction[] inputActions;

    [HideInInspector] public RoomNavigation roomNavigation;
    //for the things the player can interact with
    [HideInInspector] public List<string> interactionDescriptionsinRoom = new List<string> ();


    List<string> actionLog = new List<string>();

    // Use this for initialization
    void Awake ()
    {
        roomNavigation = GetComponent<RoomNavigation> ();
	}

    //Initial Startup Text
    void Start()
    {
        DisplayRoomText ();
        DisplayLoggedText ();
    }

    //Displays text on the console
    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", actionLog.ToArray ());

        displayText.text = logAsText;
    }

    public void DisplayRoomText()
    {
        ClearCollectionsForNewRoom();

        UnpackRoom();

        string joinedInteractionDescriptions = string.Join("\n", interactionDescriptionsinRoom.ToArray());

        //"+" joins the two strings together
        string combinedText = roomNavigation.currentRoom.description + "\n" + joinedInteractionDescriptions;

        LogStringWithReturn (combinedText);
    }

    //See Line 18 RoomNavigation.cs
    void UnpackRoom()
    {
        //See Line 18 RoomNavigation.cs
        roomNavigation.UnpackExitsInRoom();
    }

    void ClearCollectionsForNewRoom()
    {
        //clear interactions in room list
        interactionDescriptionsinRoom.Clear();
        roomNavigation.ClearExits();
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }
    
	// Update is called once per frame
	void Update () {
		
	}
}
