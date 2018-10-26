using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    //A simple variable to display Text
    public Text displayText;
    //Array for the game to comapre input to
    public InputAction[] inputActions;

    //privately creating variables hidden from inspector
    //Creates variable for room navigation
    [HideInInspector] public RoomNavigation roomNavigation;
    //for the things the player can interact with
    [HideInInspector] public List<string> interactionDescriptionsInRoom = new List<string> ();
    //Creates hidden variable for interactable Items
    [HideInInspector] public InteractableItems interactableItems;

    //Creates actionLog variable as a list
    List<string> actionLog = new List<string>();

    // Use this for initialization
    void Awake ()
    {
        interactableItems = GetComponent<InteractableItems>();
        roomNavigation = GetComponent<RoomNavigation>();
	}

    //Initial Startup Text
    void Start()
    {
        DisplayRoomText();
        DisplayLoggedText();
    }

    //Displays text on the console
    public void DisplayLoggedText()
    {
        string logAsText = string.Join ("\n", actionLog.ToArray());

        displayText.text = logAsText;
    }

    public void DisplayRoomText()
    {
        ClearCollectionsForNewRoom();

        UnpackRoom();

        string joinedInteractionDescriptions = string.Join("\n", interactionDescriptionsInRoom.ToArray());

        //"+" joins the two strings together
        string combinedText = roomNavigation.currentRoom.description + "\n" + joinedInteractionDescriptions;

        LogStringWithReturn(combinedText);
    }

    //See Line 18 RoomNavigation.cs
    void UnpackRoom()
    {
        //See Line 18 RoomNavigation.cs
        roomNavigation.UnpackExitsInRoom();
        
        //gets the current room from roomNavigation and prepares to display interactable objects in it.
        PrepareObjectsToTakeOrExamine(roomNavigation.currentRoom);
    }

    //Funtion that references InteractableItems.cs for inventory
    void PrepareObjectsToTakeOrExamine(Room currentRoom)
    {
        for (int i = 0; i < currentRoom.interactableObjectsInRoom.Length; i++)
        {
            //if it finds an item not in inventory then stores description to string variable
            string descriptionNotInInventory = interactableItems.GetObjectsNotInInventory(currentRoom, i);
            if (descriptionNotInInventory != null)
            {
                interactionDescriptionsInRoom.Add(descriptionNotInInventory);
            }

            InteractableObject interactableInRoom = currentRoom.interactableObjectsInRoom[i];

            for (int j = 0; j < interactableInRoom.interactions.Length; j++) 
            {

                Interaction interaction = interactableInRoom.interactions[j];
                
                //checks to see if the input says uses the keyword "examine"
                if (interaction.inputAction.keyWord == "examine")
                {
                    interactableItems.examineDictionary.Add(interactableInRoom.noun, interaction.textResponse);
                }

                //checks to see if the input uses the keyword "take"
                if (interaction.inputAction.keyWord == "take")
                {
                    interactableItems.takeDictionary.Add(interactableInRoom.noun, interaction.textResponse);
                }

            }

        }

    }

    public string TestVerbDictionaryWithNoun(Dictionary<string, string> verbDictionary, string verb, string noun)
    {
        //checks if word is in dictionary if it is then it will be returned to string
        if (verbDictionary.ContainsKey(noun))
        {
            return verbDictionary[noun];
        }

        //if it doesnt then it will return this:
        return "you can't" + verb + " " + noun;
    }

    void ClearCollectionsForNewRoom()
    {
        //clear interactions in room list
        interactableItems.ClearCollections();
        interactionDescriptionsInRoom.Clear();
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
