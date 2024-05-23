using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "PlayerDataSO", menuName = "Data/Player Data/WeaponSO's")]


[System.Serializable]
public class WeaponDataSO : ScriptableObject
{
    public Sprite weaponImage;

    public LocalizedString nameKey;
    // public string weaponName;
    // public string weaponNameRus;
    public string weaponDescription;
    public bool isEquiped;

    public GameObject weapon;

    public bool isOpened;

    public float cost;

}
