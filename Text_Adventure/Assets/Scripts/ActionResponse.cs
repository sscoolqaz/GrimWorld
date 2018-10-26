using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//An abstract base class much like InputAction
public abstract class ActionResponse : ScriptableObject
{
    //General variable used to check if something is possible
    public string requiredString;

    //make sure to pass scene arguments in functions!!
    public abstract bool DoActionResponse(GameController controller);

}