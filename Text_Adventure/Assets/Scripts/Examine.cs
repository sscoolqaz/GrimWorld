using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Examine")]

public class Examine : InputAction
{
    //passes sliced user input into the array
    public override void RespondToInput (GameController controller, string[] seperatedInputWords)
    {
        controller.LogStringWithReturn(controller.TestVerDictionaryWithNoun(controller.interactableItems.examinDictionary, seperatedInputWords[0], seperatedInputWords[1]));
    }
}
