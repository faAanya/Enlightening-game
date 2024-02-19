using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private PlayerController playerController;

    public float speed;
    private Vector3 aim;

    public float damage;
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        aim = playerController.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Meow");
        transform.position = Vector3.MoveTowards(transform.position, aim, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().DecreaseHealth(damage);
            Destroy(gameObject);
        }
    }
}
