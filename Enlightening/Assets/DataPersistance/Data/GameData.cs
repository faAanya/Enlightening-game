
using System;
using System.Collections.Generic;


[System.Serializable]
public class GameData
{

    public List<WeaponDataSO> playerWeaponInventory;
    public bool[] completedLevels;


    public GameData()
    {
        playerWeaponInventory = new List<WeaponDataSO>();
        completedLevels = new bool[3];
    }
}
