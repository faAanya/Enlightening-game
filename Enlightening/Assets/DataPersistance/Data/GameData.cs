
using System;
using System.Collections.Generic;


[System.Serializable]
public class GameData
{

    public List<WeaponDataSO> playerWeaponInventory;
    //public InventoryToSave inventoryToSave;

    public GameData()
    {
        playerWeaponInventory = new List<WeaponDataSO>();
        //inventoryToSave = new InventoryToSave();
    }
}
