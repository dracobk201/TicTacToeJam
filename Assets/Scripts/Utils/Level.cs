using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Level")]
public class Level : ScriptableObject
{
    public List<Wave> Waves;
    //TODO: Añadir Background
    //TODO: Añadir Plataformas
    //TODO: Posibles enemigos diferentes
    //TODO: Ubicación del objetivo
}
