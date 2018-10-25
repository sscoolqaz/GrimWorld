using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputAction : ScriptableObject
{
    //Input it responds to
    public string keyWord;

    public abstract void RespondToInput(GameController controller, string[] seperatedInputWords);
}
