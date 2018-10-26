using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputAction : ScriptableObject
{
    //Variable for keywords commands listen to
    public string keyWord;

    public abstract void RespondToInput(GameController controller, string[] separatedInputWords);
}
