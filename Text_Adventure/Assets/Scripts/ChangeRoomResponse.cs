using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/ActionsResponse/ChangeRoom")]
public class ChangeRoomResponse : ActionResponse
{
    //if you use the item something will happen
    public Room roomToChangeTo;

    //creates function that has a boolean value.
    public override bool DoActionResponse(GameController controller)
    {

        //Compares current room with desired room
        if (controller.roomNavigation.currentRoom.roomName == requiredString)
        {
            //If true it Changes to new room
            controller.roomNavigation.currentRoom = roomToChangeTo;
            controller.DisplayRoomText();
            return true;
        }

        //if it is not the desired room the dont move
        return false;

    }

}
