
using System;
using System.Collections.Generic;


[System.Serializable]
public class GameData
{

    public List<WeaponDataSO> playerWeaponInventory;
    public List<float> musicSettings;
    public bool[] levels;

    public float money;

    public int localisationLang;
    //public InventoryToSave inventoryToSave;

    public GameData()
    {
        localisationLang = 1;
        money = 100;
        levels = new bool[2];
        levels[0] = true;
        musicSettings = new List<float>(3);
        playerWeaponInventory = new List<WeaponDataSO>();
        //inventoryToSave = new InventoryToSave();
    }
}
