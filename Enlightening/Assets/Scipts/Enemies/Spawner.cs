using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Camera cam;
    public float interval;
    private bool canSpawn = true;
    private PlayerController playerController;
    public Vector3 testPos;
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
            StartCoroutine(SpawnEnemy(interval, enemy));
        }
     
    }
    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        System.Random rnd = new System.Random();

        Vector3 PosX = Camera.main.ViewportToWorldPoint(new Vector2((float)rnd.NextDouble(), rnd.Next(0,2)));
        Vector3 PosY = Camera.main.ViewportToWorldPoint(new Vector2(rnd.Next(0,2), (float)rnd.NextDouble()));

        List<Vector3> vectors = new List<Vector3>() { PosX, PosY };

        canSpawn = false;
        yield return new WaitForSeconds(interval);
        canSpawn = true;

        Instantiate(enemy, vectors[rnd.Next(0,2)], Quaternion.identity);

        StartCoroutine(SpawnEnemy(interval, enemy));
    }
 
}