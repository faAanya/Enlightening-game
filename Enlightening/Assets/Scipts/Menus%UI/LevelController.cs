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
    [SerializeField]
    public MoneySO money;

    private SpawnerKillCounter spawnerKillCounter;
    SpawnerOfEnemySpawners spawnerOfEnemySpawners;
    public static int iLevel;

    public GameObject Map;

    public Timer timer;

    public LevelCompletedUI levelCompletedUI;

    public bool uiShowed;


    void Start()
    {
        uiShowed = false;
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
            if (Map.transform.localScale.x == Map.GetComponent<MapImageController>().maxSize)
            {
                if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && !uiShowed)
                {//todo: donot invoke every fucking second pls...
                    money.amount += timer.CountMoney();
                    levelCompletedUI.ShowUI();
                    uiShowed = true;
                }
            }
            else if (Map.transform.localScale.x != Map.GetComponent<MapImageController>().maxSize)
            {
                System.Random random = new System.Random();
                spawnerOfEnemySpawners.amountOfSpawnersToSpawn += random.Next(0, spawnerOfEnemySpawners.amountOfSpawnersToSpawn + 2);
                spawnerKillCounter.counter = spawnerOfEnemySpawners.amountOfSpawnersToSpawn;
                Map.transform.localScale += new Vector3(30f, 30f, 0);
                GameObject.FindGameObjectWithTag("MinimapCamera").GetComponent<Camera>().orthographicSize += 15f;
                spawnerOfEnemySpawners.Awake();
            }
            else { }

        }
    }

}
