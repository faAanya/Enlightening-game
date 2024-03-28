using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapUI : MonoBehaviour
{
    public static Action OnMinimapEnable;
    public static Action OnMinimapDisable;
    public GameObject miniMap;

    void OnEnable()
    {
        OnMinimapEnable += ShowUI;
        OnMinimapDisable += HideUI;
    }

    private void HideUI()
    {
        miniMap.SetActive(false);
    }

    private void ShowUI()
    {
        miniMap.SetActive(true);
    }

    void OnDisable()
    {
        OnMinimapEnable -= ShowUI;
        OnMinimapDisable -= HideUI;
    }
    void Start()
    {
        miniMap.SetActive(false);
    }
}
