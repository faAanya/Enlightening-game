using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerDataSO", menuName = "Data/Player Data/MoneySO")]


[System.Serializable]
public class MoneySO : ScriptableObject
{
    public float amount;
}
