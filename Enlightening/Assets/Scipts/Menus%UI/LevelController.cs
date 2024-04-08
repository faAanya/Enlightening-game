using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public LevelsSO levelsSO;
    public Button[] buttons;

    private SpawnerKillCounter spawnerKillCounter;
    SpawnerOfEnemySpawners spawnerOfEnemySpawners;
    public static int iLevel;

    public GameObject Map;


    void Start()
    {
        iLevel = 1;
        spawnerKillCounter = GameObject.FindGameObjectWithTag("SpawnerKillCounter").GetComponent<SpawnerKillCounter>();
        spawnerOfEnemySpawners = GameObject.FindGameObjectWithTag("SpawnerSpawner").GetComponent<SpawnerOfEnemySpawners>();
        // for (int i = 0; i < buttons.Length; i++)
        // {
        //     buttons[i].interactable = levelsSO.openedLevels[i];
        // }
    }

    private void Update()
    {
        if (spawnerKillCounter.counter == 0)
        {
            System.Random random = new System.Random();
            spawnerOfEnemySpawners.amountOfSpawnersToSpawn += random.Next(0, spawnerOfEnemySpawners.amountOfSpawnersToSpawn + 2);
            spawnerKillCounter.counter = spawnerOfEnemySpawners.amountOfSpawnersToSpawn;
            Map.transform.localScale = new Vector3(Map.transform.localScale.x + 30f, Map.transform.localScale.y + 30f, 0);
            spawnerOfEnemySpawners.Awake();
        }

    }
}
