using UnityEngine;
using System;
public class UpgraderSpawner : MonoBehaviour
{
    public GameObject upgrader;
    public static Action<GameObject> OnSpawnUpgrader;

    public ScoreSliderController scoreSliderController;

    private void Start()
    {
    }
    private void Update()
    {

    }

    public void SpawnUpgrader()
    {
        System.Random rnd = new System.Random();
        Vector3 spawnPos = Camera.main.ViewportToWorldPoint(new Vector3((float)rnd.NextDouble(), (float)rnd.NextDouble()), 0);
        Instantiate(upgrader, spawnPos, Quaternion.identity);
        scoreSliderController.leveledUp = false;
    }
}
