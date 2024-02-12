using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowerLogic : MonoBehaviour
{
    private PlayerController playerController;
    public float health = 20f;
    public EnemyDataSO enemyData;
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, playerController.transform.position, 0.001f);   
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().health -= enemyData.damage;
            Debug.Log("enemy hit");
        }

        if(collision.gameObject.tag == "PlayerWeapon")
        {
            health -= 2f;
            Debug.Log("player hit");
        }
    }

}
