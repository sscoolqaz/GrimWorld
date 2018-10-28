using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//creates menu in InputActions
[CreateAssetMenu(menuName = "TextAdventure/InputActions/Take")]
//inherits from InputAction
public class Take : InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        Dictionary<string, string> takeDictionary = controller.interactableItems.Take(separatedInputWords);

        //try to take item if there is one
        if (takeDictionary != null)
        {
            controller.LogStringWithReturn(controller.TestVerbDictionaryWithNoun(takeDictionary, separatedInputWords[0], separatedInputWords[1]));
        }
    }
}
