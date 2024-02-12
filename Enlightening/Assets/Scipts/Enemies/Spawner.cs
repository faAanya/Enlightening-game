using System.Collections;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Camera cam;

    private bool canSpawn = true;
    private PlayerController playerController;
    // Use this for initialization
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(SpawnEnemy(1f, enemy));
        }
     
    }
    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        canSpawn = false;
        yield return new WaitForSeconds(interval);
        canSpawn = true;
        System.Random random = new System.Random();


        Instantiate(enemy, playerController.transform.position + new Vector3(20 - 40 * random.Next(0, 2), random.Next(-20, +20)), Quaternion.identity);

        StartCoroutine(SpawnEnemy(interval, enemy));
    }
 
}