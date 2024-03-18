using System;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSliderController : MonoBehaviour
{
    public Slider slider;
    public int nextLevelScore;


    public bool leveledUp = false;
    PlayerController playerController;

    public UpgradesClass upgradesClass;

    void Start()
    {
        nextLevelScore = 5;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        slider.minValue = 0f;
        slider.maxValue = nextLevelScore;
        slider.value = slider.minValue;
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = nextLevelScore;

        slider.value = playerController.score;

        if (slider.value == nextLevelScore)
        {
            LevelUP();
        }
    }

    public void LevelUP()
    {
        nextLevelScore += nextLevelScore;
        playerController.ResetScore();
        slider.maxValue = nextLevelScore;
        upgradesClass.ShowUI();
    }
}
