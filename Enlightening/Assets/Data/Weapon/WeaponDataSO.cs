using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataSO", menuName = "Data/Player Data/WeaponSO's")]

public class WeaponDataSO : ScriptableObject
{
    public Sprite weaponImage;
    public string weaponName;
    public string weaponDescription;
    public bool isEquiped;

    public GameObject weapon;

}
