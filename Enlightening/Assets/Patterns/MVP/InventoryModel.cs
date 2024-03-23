using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class InventoryModel
{
    public InventorySO inventory;
    public List<InventoryItem> inventoryItems = new();


}

public class InventoryItem
{
    public WeaponDataSO weapon;
    public InventoryItem(WeaponDataSO weaponData)
    {
        weapon = weaponData;
    }
}
