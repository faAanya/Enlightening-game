
using System;
using System.Collections.Generic;


[System.Serializable]
public class GameData
{

    public List<WeaponDataSO> playerWeaponInventory;
    public List<float> musicSettings;
    //public InventoryToSave inventoryToSave;

    public GameData()
    {
        musicSettings = new List<float>(3);
        playerWeaponInventory = new List<WeaponDataSO>();
        //inventoryToSave = new InventoryToSave();
    }
}
