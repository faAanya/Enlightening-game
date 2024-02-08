using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerDataSO", menuName = "Data/Player Data/WeaponSO's")]

public class WeaponDataSO :ScriptableObject
{
    public float damage;
    public float duration;
    public float coolDown;
    public float range;
}
