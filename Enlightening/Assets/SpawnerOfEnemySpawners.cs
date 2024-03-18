using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerOfEnemySpawners : MonoBehaviour
{

    public static Action OnSpawnerDie;



    public List<GameObject> spawners;
    public GameObject Map;

    void Awake()
    {

        System.Random random = new System.Random();
        for (int i = 0; i < spawners.Count; i++)
        {
            Debug.Log("SpawnerSpawner");
            int x = random.Next(-(int)Map.gameObject.transform.localScale.x + 40, (int)Map.gameObject.transform.localScale.x - 40);
            int y = random.Next(-(int)Map.gameObject.transform.localScale.y + 40, (int)Map.gameObject.transform.localScale.y - 40);

            GameObject newSpawner = spawners[i];
            Instantiate(newSpawner, new Vector2(x, y), Quaternion.identity);
            newSpawner.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // foreach (var item in spawners)
        // {
        //     if (item == null)
        //     {
        //         spawners.Remove(gameObject);
        //     }
        // }
    }
}
