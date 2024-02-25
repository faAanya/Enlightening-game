using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class UpgradesClass : MonoBehaviour
{
    private PlayerWeaponController playerWeaponController;

    private void Start()
    {
        playerWeaponController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWeaponController>();


    }

    private void Update(){
        for (int i = 0; i < playerWeaponController.weapons.Length; i++)
        {
            //playerWeaponController.weapons[i].GetComponent
        }

    }
}
