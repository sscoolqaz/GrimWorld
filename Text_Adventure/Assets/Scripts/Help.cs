using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//creates menu in InputActions
[CreateAssetMenu(menuName = "TextAdventure/InputActions/Help")]
//inherits from InputAction
public class Help : InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        controller.LogStringWithReturn("This is the help cokmand");
    }
}
