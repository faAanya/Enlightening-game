using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private PlayerController playerController;

    public float speed;
    private Vector3 aim;

    public float damage;
    public float range;
    public Vector3 startPos;

    private Rigidbody2D rbBullet;
    void Start()
    {
        startPos = transform.position;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        aim = playerController.transform.position - transform.position;
        rbBullet = GetComponent<Rigidbody2D>();

        rbBullet.velocity = new Vector2(aim.x, aim.y).normalized * 2;

        Vector3 rotation = transform.position - aim;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rot + 90f);
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(gameObject.transform.position, startPos) > range)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().DecreaseHealth(damage);
            Destroy(gameObject);
        }
    }
}
