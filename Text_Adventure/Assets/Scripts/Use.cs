using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//creates a menu in the creation menu
[CreateAssetMenu(menuName = "TextAdventure/InputActions/Use")]
//Use inherits from InputAciton
public class Use : InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        controller.interactableItems.UseItem(separatedInputWords);
    }
}
