using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{

    public UpgradesClass upgradesClass;
    public InventorySO inventory;

    private void Start()
    {

        for (int j = 0; j < inventory.allWeapons.Count; j++)
        {

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
        }
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
}

[System.Serializable]
public class WeaponClassToSave
{
    public Sprite weaponImage;
    public string weaponName;
    public string weaponDescription;
    public bool isEquiped;

    public GameObject weapon;
}
