using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometeEnemy : MonoBehaviour
{

    private Enemy enemy;
    public GameObject comete;
    private bool canFly = true;
    private PlayerController playerController;

    public Vector3 pos;
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        enemy = comete.gameObject.GetComponent<Enemy>();
        pos = GenerateRandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(canFly);
        transform.position = Vector3.MoveTowards(gameObject.transform.position, pos, .07f);

        if (enemy.health >= 0)
        {
            if (transform.position != pos)
            {
                comete.SetActive(true);
            }
            else
            {
                comete.SetActive(false);
            }
            if (canFly)
            {
                StartCoroutine(CometeFly());
            }
        }

    }

    public Vector3 GenerateRandomPos()
    {

        System.Random rnd = new System.Random();
        Vector3 PosX = playerController.transform.position + new Vector3(10 - 20 * rnd.Next(0, 2), rnd.Next(-10, +20));
        Vector3 PosY = playerController.transform.position + new Vector3(rnd.Next(-10, +20), 10 - 20 * rnd.Next(0, 2));
        List<Vector3> vectors = new List<Vector3>() { PosX, PosY };

        return vectors[rnd.Next(0, 2)];
    }

    public IEnumerator CometeFly()
    {
        canFly = false;

        yield return new WaitForSeconds(enemy.coolDown);
        transform.position = GenerateRandomPos();

        pos = -transform.position;
        canFly = true;
    }
}
