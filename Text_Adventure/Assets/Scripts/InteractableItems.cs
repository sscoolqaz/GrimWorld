using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{

    //list of all the usable items in the game
    public List<InteractableObject> usableItemList;

    //creates a dictionary for Interactable Items
    public Dictionary<string, string> examineDictionary = new Dictionary<string, string>();

    //creates a dictionary for Items you take
    public Dictionary<string, string> takeDictionary = new Dictionary<string, string>();

    //creats an array of items in the room
    [HideInInspector] public List<string> nounsInRoom = new List<string>();

    //creates a dictionary for the "use" command
    //input a string key and get out a response
    Dictionary<string, ActionResponse> useDictionary = new Dictionary<string, ActionResponse>();

    //creats an array of items that are in the players inventory
    List<string> nounsInInventory = new List<string>();

    //private GameController
    GameController controller;

    private void Awake()
    {
        controller = GetComponent<GameController>();
    }

    public string GetObjectsNotInInventory(Room currentRoom, int i)
    {
        InteractableObject interactableInRoom = currentRoom.interactableObjectsInRoom[i];

        //checks if item is in inventory or room
        if (!nounsInInventory.Contains(interactableInRoom.noun))
        {
            nounsInRoom.Add(interactableInRoom.noun);
            return interactableInRoom.description;
        }

        return null;

    }

    public void AddActionResponsesToUseDictionary()
    {
        //looping over all the nouns in the inventory
        for (int i = 0; i < nounsInInventory.Count; i++)
        {
            string noun = nounsInInventory[i];

            InteractableObject interactableObjectInInventory = GetInteractableObjectFromUsableList(noun);
            
            //if GetInteractableObjectFromUsableList returns null skip this loop
            if (interactableObjectInInventory == null)
                continue;
            for (int j = 0; j < interactableObjectInInventory.interactions.Length; j++)
            {
                Interaction interaction = interactableObjectInInventory.interactions[j];

                if (interaction.actionResponse == null)
                    continue;
                //if the dictionary does NOT contain the noun (
                if (!useDictionary.ContainsKey(noun))
                {
                    useDictionary.Add(noun, interaction.actionResponse);
                }
            }
        }
    }

    //function to return the interactable objects
    InteractableObject GetInteractableObjectFromUsableList(string noun)
    {
        for (int i = 0; i < usableItemList.Count; i++)
        {
            //if the noun in inventory is the one we requested it will return the item
            if (usableItemList[i].noun == noun)
            {
                return usableItemList[i];
            }

        }
        return null;
    }

    //function to display inventory
    public void DisplayInventory()
    {
        controller.LogStringWithReturn("You have the following items: ");

        //Checks inv by incrementing an array
        for (int i = 0; i < nounsInInventory.Count; i++)
        {
            controller.LogStringWithReturn(nounsInInventory[i]);
        }

    }

    //used to clear the collections everytime we change rooms
    public void ClearCollections()
    {
        //cleans the "examine" dictionary of data
        examineDictionary.Clear();
        //cleans the "take" dictionary of its data
        takeDictionary.Clear();
        nounsInRoom.Clear();
    }


    public Dictionary<string, string> Take(string[] separatedInputWords)
    {
        string noun = separatedInputWords[1];

        //checks if the noun (object) in the room
        //then takes the item if it is in the room
        //returns the dictionary to the take input action

        if (nounsInRoom.Contains(noun))
        {
            nounsInInventory.Add(noun);
            AddActionResponsesToUseDictionary();
            nounsInRoom.Remove(noun);
            return takeDictionary;
        }
        
        //if it fails
        else
        {
            controller.LogStringWithReturn("there is no " + noun + " here to take.");
            return null;
        }
    }

    //not going to give a text response cause ActionResponse already gives one
    public void UseItem(string[] separatedInputWords)
    {
        string nounToUse = separatedInputWords[1];

        //have to make sure to check if the item is in the inventory
        if (nounsInInventory.Contains(nounToUse))
        {
            //need to make sure its also in the dictionary
            if (useDictionary.ContainsKey(nounToUse))
            {
                //returns a boolean 
                bool actionResult = useDictionary[nounToUse].DoActionResponse(controller);

                //if actionResult isnt true
                if (!actionResult)
                {
                    controller.LogStringWithReturn("Hmm. Nothing happens.");
                }

            }

            //In case its not in the use dictionary
            else
            {
                controller.LogStringWithReturn("You can't use that lmao!");
            }

        }

        //if the item does not even exist in the players inventory.
        else
        {
            controller.LogStringWithReturn("That doesn't exist! Try something a little more real.");
        }

    }
    
}
