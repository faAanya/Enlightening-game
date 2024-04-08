using TMPro;
using UnityEngine;

public class SpawnerKillCounter : MonoBehaviour
{
    public TMP_Text spawnerCounter;
    public SpawnerOfEnemySpawners spawnerOfEnemySpawners;

    public int counter;
    void Awake()
    {
        counter = GameObject.FindGameObjectWithTag("SpawnerSpawner").GetComponent<SpawnerOfEnemySpawners>().amountOfSpawnersToSpawn;
    }
    void Update()
    {
        spawnerCounter.text = $"Spawners left {counter}";
    }

}
