
using System.Collections.Generic;

[System.Serializable]
public class InventoryToSave
{

    public int staticInventorySize;
    public List<WeaponClassToSave> weapons;
    public List<WeaponClassToSave> allWeapons;

    public InventoryToSave()
    {
        staticInventorySize = 3;
        weapons = new List<WeaponClassToSave>();
    }

}
