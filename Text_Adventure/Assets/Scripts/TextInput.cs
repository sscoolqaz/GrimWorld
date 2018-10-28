using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//needed to access the UI elements
using UnityEngine.UI;

public class TextInput : MonoBehaviour 
{
    //variable for Input field type
	public InputField inputField;

	GameController controller;

	void Awake()
	{
		controller = GetComponent<GameController> ();
        //used to call AssceptStringInput when an event is activated
		inputField.onEndEdit.AddListener (AcceptStringInput);
	}

	void AcceptStringInput(string userInput)
	{
        //converts the users input to lowercase and sets the user input variable
		userInput = userInput.ToLower ();
        //Takes user input and mirrors it back to the user
		controller.LogStringWithReturn (userInput);

        //sets the character for the array to split
		char[] delimiterCharacters = { ' ' };
        //seperates the input into an array
		string[] separatedInputWords = userInput.Split (delimiterCharacters);

		for (int i = 0; i < controller.inputActions.Length; i++) 
		{
			InputAction inputAction = controller.inputActions [i];
			if (inputAction.keyWord == separatedInputWords [0]) 
			{
				inputAction.RespondToInput (controller, separatedInputWords);
			}
		}

		InputComplete ();

	}

    //Function that displays text on screen, reactivates input, and sets the input to nothing.
	void InputComplete()
	{
        //Displays text in log
		controller.DisplayLoggedText ();
        //Re-Sets the input field as active
		inputField.ActivateInputField ();
        //Used to clear the user's input after they press enter
		inputField.text = null;
	}

}
