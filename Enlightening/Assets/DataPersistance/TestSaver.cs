using System;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour, IDataPersistence
{
    public InventorySO inventory;
    public List<WeaponDataSO> weaponClassToSave;
    void Awake()
    {
        for (int i = 0; i < inventory.weapons.Count; i++)
        {
            weaponClassToSave.Add(inventory.weapons[i]);
        }
    }
    public void LoadData(GameData gameData)
    {
        inventory.weapons = gameData.playerWeaponInventory;
    }

    public void SaveData(ref GameData gameData)
    {
        for (int i = 0; i < inventory.weapons.Count; i++)
        {
            weaponClassToSave.Add(inventory.weapons[i]);
        }
        gameData.playerWeaponInventory = weaponClassToSave;

    }
}

