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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().DecreaseHealth(damage);
            //SliderController.HelthSliderChange?.Invoke(enemy.damage);
            Debug.Log("enemy hit");
        }

        if (collision.gameObject.tag == "PlayerWeapon")
        {
            health -= collision.gameObject.GetComponent<Weapon>().damage;
            Debug.Log("player hit");
        }
    }

    public void Die()
    {
        for (int i = 0; i <= enemyCost; i++)
        {
            System.Random rnd = new System.Random();
            Instantiate(orb, transform.position + new Vector3((float)rnd.NextDouble(), (float)rnd.NextDouble(),0), Quaternion.identity);
        }
        
        Destroy(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();

        }
    }
}
