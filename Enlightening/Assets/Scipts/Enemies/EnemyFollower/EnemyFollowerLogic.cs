using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowerLogic : MonoBehaviour
{
    private PlayerController playerController;
    public Enemy enemy;


    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, playerController.transform.position, 0.01f);
        }

    }
}
