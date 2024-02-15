using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSliderController : MonoBehaviour
{
    public Slider slider;
    public int[] levels;
    public int currentLevel;


    Player playerController;
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        slider.minValue = 0f;
        slider.maxValue = levels[0];
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = levels[currentLevel];

        slider.value = playerController.score;

        if (slider.value == levels[currentLevel])
        {
            currentLevel++;
            playerController.ResetScore();
            slider.maxValue = levels[currentLevel];
        }
    }
}
