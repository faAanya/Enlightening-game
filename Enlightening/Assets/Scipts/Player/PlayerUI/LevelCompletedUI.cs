using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletedUI : MonoBehaviour
{
    float startMoney;
    public MoneySO money;
    public GameObject levelCompletedUI;
    public GameObject Map;
    void Start()
    {
        levelCompletedUI.SetActive(false);
        startMoney = money.amount;
    }



    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("SpawnerKillCounter").GetComponent<SpawnerKillCounter>().counter <= 0
        && GameObject.FindGameObjectsWithTag("Enemy") == null && Map.transform.localScale.x == 50f)
        {
            ShowUI();
        }
    }

    public void ShowUI()
    {
        levelCompletedUI.GetComponent<LevelCompletedController>().earnedMoney.text = $"Earned moeny{money.amount - startMoney}";
        levelCompletedUI.SetActive(true);
        Time.timeScale = 0;
    }

}
