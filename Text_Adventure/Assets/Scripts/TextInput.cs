using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//needed to access the UI elements
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    //Variable for InputField Type
    public InputField inputField;

    GameController controller;

    void Awake()
    {
        controller = GetComponent<GameController> ();
        //Used to call AcceptStringInput when on end edit is event is activated
        inputField.onEndEdit.AddListener (AcceptStringInput);
    }

    void AcceptStringInput(string userInput)
    {
        //Converts the input to lowercase
        userInput = userInput.ToLower ();
        //Take user input and mirror it back to the User
        controller.LogStringWithReturn (userInput);

        //If there is a space  it will break it into two different objects in the array
        char[] delimiterCharacters = { ' ' };
        string[] seperatedInputWords = userInput.Split (delimiterCharacters);

        for (int i = 0; i < controller.inputActions.Length; i++)
        {
            InputAction inputAction = controller.inputActions [i];
            //if there is a keyword match (word 1) then it wil respond to input
            //The Action word is the word 1
            if (inputAction.keyWord == seperatedInputWords [0])
            {
                inputAction.RespondToInput (controller, seperatedInputWords);
            }
        }

        InputComplete ();

    }

    //Function for input complete
    void InputComplete ()
    {
        controller.DisplayLoggedText ();
        inputField.ActivateInputField ();
        //Used to clear the user input after they press enter.
        inputField.text = null;
    }


}
