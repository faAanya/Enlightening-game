using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "InventoryData", menuName = "Data/Inventory Data/InventorySO")]
public class InventorySO : ScriptableObject
{

    public int staticInventorySize = 3;
    public List<WeaponDataSO> weapons;
    public List<WeaponDataSO> allWeapons;


}
