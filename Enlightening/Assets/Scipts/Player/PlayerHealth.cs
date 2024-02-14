using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;

    public void IncreaseHealth(float buff)
    {
        health += buff;
    } 
    public void DecreaseHealth(float damage)
    {
        health -= damage;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
