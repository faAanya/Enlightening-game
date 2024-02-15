using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public float score;


    public void IncreaseHealth(float buff)
    {
        health += buff;
    } 
    public void DecreaseHealth(float damage)
    {
        health -= damage;
    } 
    public void IncreaseScore() 
    {
        score++; 
    } 
    public void ResetScore()
    {
        score = 0;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
