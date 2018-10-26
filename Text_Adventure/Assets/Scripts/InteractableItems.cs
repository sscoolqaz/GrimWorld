using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{

    //creates a dictionary for Interactable Items
    public Dictionary<string, string> examinDictionary = new Dictionary<string, string>();

    //creats an array of items in the room
    [HideInInspector] public List<string> nounsInRoom = new List<string>();

    //creats an array of items that are in the players inventory
    List<string> nounsInInventory = new List<string>();


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


    //used to clear the collections everytime we change rooms
    public void ClearCollections()
    {
        examinDictionary.Clear();
        nounsInRoom.Clear();
    }
}
