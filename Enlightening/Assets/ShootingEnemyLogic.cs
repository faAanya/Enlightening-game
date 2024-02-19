using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyLogic : MonoBehaviour
{

    private bool canAttack = true;
    private PlayerController playerController;

    public float distance;

    public GameObject bullet;
    public float speed;

    private Enemy enemy;
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(gameObject.transform.position, playerController.transform.position) < distance)
        {
            if (canAttack)
            {
                StartCoroutine(Shoot(enemy.coolDown, bullet));
            }
          
        }
        else
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, playerController.transform.position, speed * Time.deltaTime);
        }
    }

    private IEnumerator Shoot(float interval, GameObject bullet)
    {
        canAttack = false;
        yield return new WaitForSeconds(interval);
        canAttack = true;

        GameObject newBullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);

        StartCoroutine(Shoot(interval, bullet));
    }
}
