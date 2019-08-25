using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Wave")]
public class Wave : ScriptableObject
{
    public FloatReference Time;
    public IntReference MaxEnemyInScreen;
    public FloatReference FlyingEnemyFrequency;
    public FloatReference GroundEnemyFrequency;
    public FloatReference EnemyVelocityFactor;
}
