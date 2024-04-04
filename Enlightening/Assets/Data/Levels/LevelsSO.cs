using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerDataSO", menuName = "Data/Player Data/Levels's")]
public class LevelsSO : ScriptableObject
{
    public int levelAmout = 5;
    public bool[] openedLevels;
}
