using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Examine")]
public class Examine : InputAction
{
    //passes sliced user input into the array
    public override void RespondToInput (GameController controller, string[] separatedInputWords)
    {
        controller.LogStringWithReturn (controller.TestVerbDictionaryWithNoun (controller.interactableItems.examineDictionary, separatedInputWords [0], separatedInputWords [1]));
    }
}
