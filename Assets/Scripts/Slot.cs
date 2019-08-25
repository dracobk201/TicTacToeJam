using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Slot")]
public class Slot : ScriptableObject
{
    public SlotState state;
    public IntReference XPosition;
    public IntReference YPosition;
}
