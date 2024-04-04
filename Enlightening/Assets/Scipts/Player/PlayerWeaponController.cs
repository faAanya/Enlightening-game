using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{

    public UpgradesClass upgradesClass;
    public InventorySO inventory;
    //public GameObject[] weaponsGameObjects;
    private void Awake()
    {

        //weaponsGameObjects = new GameObject[inventory.weapons.Count];
        for (int j = 0; j < inventory.allWeapons.Count; j++)
        {
            Debug.Log(inventory.allWeapons.Count);
            GameObject item = Instantiate(inventory.allWeapons[j].weapon, gameObject.transform.position, Quaternion.identity);
            item.transform.SetParent(gameObject.transform);
            upgradesClass.weapons.Add(item.GetComponent<WeaponClass>());
            if (inventory.allWeapons[j].isEquiped)
            {
                item.GetComponent<WeaponClass>().enabled = true;
            }
            else
            {
                item.GetComponent<WeaponClass>().enabled = false;
            }
            //            weaponsGameObjects[j] = gameObject.transform.GetChild(j).gameObject;

        }
        // for (int i = 0; i < weaponsGameObjects.Length; i++)
        // {
        //     weaponsGameObjects[i].GetComponent<Transform>().transform.position = Vector3.zero;
        //     ShowActiveWeapon();

        // }
    }
    private void Update()
    {

        // ShowActiveWeapon();
        // for (int i = 0; i < weaponsGameObjects.Length; i++)
        // {
        //     weaponsGameObjects[i].GetComponent<Transform>().transform.position = transform.position;


        // }
    }

    public void ShowActiveWeapon()
    {
        // for (int i = 0; i < weaponsGameObjects.Length; i++)
        // {
        //     if (!weaponsGameObjects[i].GetComponent<WeaponClass>().isAvaliable)
        //     {
        //         weaponsGameObjects[i].GetComponent<WeaponClass>().gameObject.SetActive(false);
        //     }
        //     if (weaponsGameObjects[i].GetComponent<WeaponClass>().isAvaliable)
        //     {
        //         weaponsGameObjects[i].GetComponent<WeaponClass>().gameObject.SetActive(true);
        //     }

        // }
    }


    public void LoadData(GameData gameData)
    {
        inventory.weapons.AddRange(gameData.playerWeaponInventory);
    }

    public void SaveData(ref GameData gameData)
    {

        gameData.playerWeaponInventory = inventory.weapons;
    }

}
