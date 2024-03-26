using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    public GameObject levelCompletedUI;

    public static Action OnPauseEnable;
    public static Action OnPauseDisable;

    void OnEnable()
    {
        OnPauseEnable += ShowUI;
        OnPauseDisable += HideUI;
    }

    void OnDisable()
    {
        OnPauseEnable -= ShowUI;
        OnPauseDisable -= HideUI;
    }
    void Start()
    {
        levelCompletedUI.SetActive(false);

    }

    public void ShowUI()
    {
        levelCompletedUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void HideUI()
    {
        levelCompletedUI.SetActive(false);
        Time.timeScale = 1;
    }
}
