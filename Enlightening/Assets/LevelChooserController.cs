using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelChooserController : MonoBehaviour, IDataPersistence
{
    public LevelsSO levelsSO;
    public Button[] buttons;

    public void LoadData(GameData gameData)
    {
        levelsSO.openedLevels = gameData.levels;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.levels = levelsSO.openedLevels;
    }


    void Awake()
    {
        for (int i = 0; i < levelsSO.openedLevels.Length; i++)
        {
            buttons[i].interactable = levelsSO.openedLevels[i];
        }
    }

}
