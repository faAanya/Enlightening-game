using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using FMODUnity;


[RequireComponent(typeof(StudioEventEmitter))]
public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    //public Camera cam;
    public float interval;
    private bool canSpawn = true;
    private PlayerController playerController;
    public Vector3 testPos;
    public float health;

    public int amount;

    SpawnerOfEnemySpawners spawnerOfEnemySpawners;
    private SpawnerKillCounter spawnerKillCounter;

    private StudioEventEmitter emitter;



    void Awake()
    {

        // emitter = AudioManager.Instance.InitializeEventEmitter(FMODEvents.Instance.spawnerIdle, gameObject);
        // emitter.Play();
        spawnerKillCounter = GameObject.FindGameObjectWithTag("SpawnerKillCounter").GetComponent<SpawnerKillCounter>();
        spawnerOfEnemySpawners = GameObject.FindGameObjectWithTag("SpawnerSpawner").GetComponent<SpawnerOfEnemySpawners>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //   cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
        SpawnerOfEnemySpawners.OnSpawnerDie -= () => { spawnerKillCounter.counter++; };

        if (canSpawn)
        {
            StartCoroutine(SpawnEnemy(interval, enemy));
        }
    }
    public void Die()
    {
        // emitter.Stop();
        // AudioManager.Instance.PlayOneShot(FMODEvents.Instance.enemyDeath, this.transform.position);
        spawnerKillCounter.counter--;
        Destroy(gameObject);
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
        for (int i = 0; i < rnd.Next(1, amount + 1); i++)
        {
            Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
        }

        StartCoroutine(SpawnEnemy(interval, enemy));
    }

}