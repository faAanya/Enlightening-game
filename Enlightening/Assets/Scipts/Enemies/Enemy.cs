using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float damage;

    public float coolDown;


    public GameObject orb;

    public int enemyCost;



    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        for (int i = 0; i < enemyCost; i++)
        {
            System.Random rnd = new System.Random();
            Instantiate(orb, transform.position + new Vector3((float)rnd.NextDouble(), (float)rnd.NextDouble(), 0), Quaternion.identity);
        }

        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().DecreaseHealth(damage);
        }
    }
}
