using TMPro;
using UnityEngine;

public class SpawnerKillCounter : MonoBehaviour
{
    public TMP_Text spawnerCounter;
    SpawnerOfEnemySpawners spawnerOfEnemySpawners;

    public int counter;
    void Awake()
    {
        counter = GameObject.FindGameObjectWithTag("SpawnerSpawner").GetComponent<SpawnerOfEnemySpawners>().spawners.Count;
        // spawnerOfEnemySpawners = GameObject.FindGameObjectWithTag("SpawnerSpawner").GetComponent<SpawnerOfEnemySpawners>();
        // spawnerOfEnemySpawners.spawners.TrimExcess();
    }
    void Update()
    {
        Debug.Log(counter);
        spawnerCounter.text = $"Spawners left {counter}";
    }

}
