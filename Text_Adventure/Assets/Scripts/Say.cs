using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Say")]
public class Say : InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        controller.roomNavigation.AttemptToSaySomething(separatedInputWords[1]);
    }
}
