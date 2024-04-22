using System;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour, IDataPersistence
{
    public InventorySO inventory;

    public LevelsSO levelsSO;
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

        for (int i = 0; i < gameData.playerWeaponInventory.Count; i++)
        {
            Debug.Log(gameData.playerWeaponInventory[i].GetInstanceID());
            if (gameData.playerWeaponInventory[i].GetInstanceID() == 0)
            {
                gameData.playerWeaponInventory.RemoveAt(i);
            }
        }
        levelsSO.openedLevels = gameData.levels;
        inventory.weapons = gameData.playerWeaponInventory;
    }



    public void SaveData(ref GameData gameData)
    {
        gameData.levels = levelsSO.openedLevels;
        weaponClassToSave = new List<WeaponDataSO>();
        for (int i = 0; i < inventory.weapons.Count; i++)
        {
            weaponClassToSave.Add(inventory.weapons[i]);
        }

        gameData.playerWeaponInventory = weaponClassToSave;

    }
}

