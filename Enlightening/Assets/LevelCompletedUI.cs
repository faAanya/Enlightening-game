using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletedUI : MonoBehaviour
{
    private GameObject levelCompleted;
    SpawnerKillCounter spawnerKillCounter;

    public GameObject levelCompletedUI;
    void Start()
    {
        levelCompletedUI.SetActive(false);

    }



    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("SpawnerKillCounter").GetComponent<SpawnerKillCounter>().counter <= 0
        && GameObject.FindGameObjectsWithTag("Enemy") != null)
        {
            ShowUI();
        }
    }

    public void ShowUI()
    {
        levelCompletedUI.SetActive(true);
        // Time.timeScale = 0;
    }

}
