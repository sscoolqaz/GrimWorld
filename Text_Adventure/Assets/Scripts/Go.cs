using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Go")]

public class Go : InputAction
{
    public override void RespondToInput(GameController controller, string[] seperatedInputWords)
    {
        //passes input to game controller dont create variables for scene objects
        //Second Word is passed to AttempToChangeRooms
        controller.roomNavigation.AttemptToChangeRooms(seperatedInputWords[1]);
    }
}
