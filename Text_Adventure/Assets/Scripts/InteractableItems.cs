using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{
    //creates list of all the usable items in the game
    public List<InteractableObject> usableItemList;

    //creates dictionaries for Interactable Items, and Items.
    public Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
    public Dictionary<string, string> takeDictionary = new Dictionary<string, string>();

    //creates an array for items
    [HideInInspector] public List<string> nounsInRoom = new List<string>();

    Dictionary<string, ActionResponse> useDictionary = new Dictionary<string, ActionResponse>();
    List<string> nounsInInventory = new List<string>();
    GameController controller;

    void Awake()
    {
        controller = GetComponent<GameController>();
    }

    public string GetObjectsNotInInventory(Room currentRoom, int i)
    {
        InteractableObject interactableInRoom = currentRoom.interactableObjectsInRoom[i];

        if (!nounsInInventory.Contains(interactableInRoom.noun))
        {
            nounsInRoom.Add(interactableInRoom.noun);
            return interactableInRoom.description;
        }

        return null;
    }

    //Function to add the Actions to the use dictionary.
    public void AddActionResponsesToUseDictionary()
    {
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
            //if the Item in inventory is the one we requested it will return the item
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
        controller.LogStringWithReturn("You look in your backpack, inside you have: ");

        for (int i = 0; i < nounsInInventory.Count; i++)
        {
            controller.LogStringWithReturn(nounsInInventory[i]);
        }
    }

    //used to clear the arrays and dictionaryies
    public void ClearCollections()
    {
        examineDictionary.Clear();
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
            controller.LogStringWithReturn("There is no " + noun + " here to take.");
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
                //returns a boolean value
                bool actionResult = useDictionary[nounToUse].DoActionResponse(controller);
                //if actionResult isnt true
                if (!actionResult)
                {
                    //used to give a hint to the user that this isnt the right place
                    controller.LogStringWithReturn("Hmm. Nothing happens.");
                }
            }
            else
            {
                //if it doesnt exist
                controller.LogStringWithReturn("You can't use the " + nounToUse);
            }
        }
        else
        {
            //if its not even in the inventory
            controller.LogStringWithReturn("There is no " + nounToUse + " in your inventory to use");
        }
    }

}
