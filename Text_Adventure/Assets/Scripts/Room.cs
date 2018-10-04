using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Text_Adventure/Room")]
public class Room : ScriptableObject
{

    [TextArea]
    public string description;
    public string roomName;

}
