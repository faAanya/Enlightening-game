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

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, playerController.transform.position, 0.001f);   
        if(enemy.health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().DecreaseHealth(enemy.damage);
            Debug.Log("enemy hit");
        }

        if(collision.gameObject.tag == "PlayerWeapon")
        {
            enemy.health -= collision.gameObject.GetComponent<Weapon>().damage;
            Debug.Log("player hit");
        }
    }

}
