using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{

    public GameObject tutorialGO;
    public bool isOpened;
    public void Start()
    {
        isOpened = true;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            tutorialGO.SetActive(true);
            Time.timeScale = 0;
        }


    }
}
