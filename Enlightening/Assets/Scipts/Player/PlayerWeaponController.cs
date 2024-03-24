using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{


    public InventorySO inventory;
    public GameObject[] weaponsGameObjects;
    private void Awake()
    {

        weaponsGameObjects = new GameObject[inventory.weapons.Count];
        for (int j = 0; j < inventory.weapons.Count; j++)
        {
            GameObject item = Instantiate(inventory.weapons[j].weapon, gameObject.transform.position, Quaternion.identity);
            item.transform.SetParent(gameObject.transform);

            weaponsGameObjects[j] = gameObject.transform.GetChild(j).gameObject;
        }
        for (int i = 0; i < weaponsGameObjects.Length; i++)
        {
            weaponsGameObjects[i].GetComponent<Transform>().transform.position = Vector3.zero;
            ShowActiveWeapon();

        }
    }
    private void Update()
    {

        ShowActiveWeapon();
        for (int i = 0; i < weaponsGameObjects.Length; i++)
        {
            weaponsGameObjects[i].GetComponent<Transform>().transform.position = transform.position;


        }
    }

    public void ShowActiveWeapon()
    {
        for (int i = 0; i < weaponsGameObjects.Length; i++)
        {
            if (!weaponsGameObjects[i].GetComponent<WeaponClass>().isAvaliable)
            {
                weaponsGameObjects[i].GetComponent<WeaponClass>().gameObject.SetActive(false);
            }
            if (weaponsGameObjects[i].GetComponent<WeaponClass>().isAvaliable)
            {
                weaponsGameObjects[i].GetComponent<WeaponClass>().gameObject.SetActive(true);
            }

        }
    }
}
