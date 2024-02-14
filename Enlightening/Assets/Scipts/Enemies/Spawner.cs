using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;
using Unity.Mathematics;

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
        Vector3 PosX = playerController.transform.position + new Vector3(10 - 20 * rnd.Next(0, 2), rnd.Next(-10, +20));
        Vector3 PosY = playerController.transform.position + new Vector3(rnd.Next(-10, +20), 10 - 20 * rnd.Next(0, 2));
       

        List<Vector3> vectors = new List<Vector3>() { PosX, PosY };

        canSpawn = false;
        yield return new WaitForSeconds(interval);
        canSpawn = true;
        Instantiate(enemy, vectors[rnd.Next(0,2)], Quaternion.identity);
        StartCoroutine(SpawnEnemy(interval, enemy));
    }
 
}