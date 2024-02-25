using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [HideInInspector]
    public float damage;
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Enemy"){
            Debug.Log($"collied {damage}");
            collider.gameObject.GetComponent<Enemy>().health -= damage;
        }
    }
}
