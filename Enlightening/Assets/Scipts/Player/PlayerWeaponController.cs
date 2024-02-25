using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public GameObject[] weapons;

    private void Start()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].GetComponent<Transform>().transform.position = Vector3.zero;
            Debug.Log(weapons[i].GetComponent<WeaponClass>().damage);
        
        }
    }
    private void Update()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].GetComponent<Transform>().transform.position = transform.position;
        
            
        }
       
        
    }
}
