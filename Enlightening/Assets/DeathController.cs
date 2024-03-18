using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathController : MonoBehaviour
{


    [Header("Buttons")]
    public Button restartButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener(() => { Time.timeScale = 1; SceneManager.LoadScene("SampleScene 1"); });
        quitButton.onClick.AddListener(() => { Time.timeScale = 1; SceneManager.LoadScene("Main Menu"); });
    }

}
