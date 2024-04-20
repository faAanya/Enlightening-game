using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SpawnerOfEnemySpawners : MonoBehaviour
{

    public static Action OnSpawnerDie;

    public List<GameObject> typeOfSpawners;
    public int amountOfSpawnersToSpawn;


    public GameObject Map;

    public void Awake()
    {
        System.Random random = new System.Random();
        for (int i = 0; i < amountOfSpawnersToSpawn; i++)
        {

            int x = random.Next(-(int)Map.gameObject.transform.localScale.x + (int)(Map.gameObject.transform.localScale.x * 0.45f), (int)Map.gameObject.transform.localScale.x - (int)(Map.gameObject.transform.localScale.x * 0.45f));
            int y = random.Next(-(int)Map.gameObject.transform.localScale.y + (int)(Map.gameObject.transform.localScale.x * 0.45f), (int)Map.gameObject.transform.localScale.y - (int)(Map.gameObject.transform.localScale.x * 0.45f));

            System.Random random1 = new System.Random();
            int randomIndex = random1.Next(0, typeOfSpawners.Count);

            GameObject newSpawner = typeOfSpawners[randomIndex];
            Instantiate(newSpawner, new Vector2(x, y), Quaternion.identity);
            newSpawner.SetActive(true);
        }
    }


    void Update()
    {

    }
}
