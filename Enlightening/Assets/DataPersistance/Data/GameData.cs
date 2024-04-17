
using System;
using System.Collections.Generic;


[System.Serializable]
public class GameData
{

    public List<WeaponDataSO> playerWeaponInventory;
    public List<float> musicSettings;
    public bool[] levels;
    //public InventoryToSave inventoryToSave;

    public GameData()
    {
        levels = new bool[2];
        musicSettings = new List<float>(3);
        playerWeaponInventory = new List<WeaponDataSO>();
        //inventoryToSave = new InventoryToSave();
    }
}
