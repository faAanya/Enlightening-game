using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public GameObject[] weaponsGameObjects;

    private void Start()
    {



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
