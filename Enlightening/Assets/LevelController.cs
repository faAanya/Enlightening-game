using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;

    public LevelsSO levelsSO;

    public Button[] buttons;

    //public static Action OnLevelOpened;

    [SerializeField]
    public LevelButtonsDict ButtonDictClass;

    [SerializeField]
    public Dictionary<Button, bool> ButtonDict;

    [Serializable]
    public class NewDictItem
    {
        [SerializeField]
        public bool isAvailable;

        [SerializeField]
        public Button levelButton;
    }

    [Serializable]
    public class LevelButtonsDict
    {
        [SerializeField]
        NewDictItem[] newDictItems;

        public Dictionary<Button, bool> ToDictionary()
        {
            Dictionary<Button, bool> dict = new Dictionary<Button, bool>();

            foreach (var item in newDictItems)
            {
                dict.Add(item.levelButton, item.isAvailable);
            }
            return dict;
        }
    }

    void Start()
    {
        //     ButtonDict = ButtonDictClass.ToDictionary();

        //     foreach (var item in ButtonDict.Keys.ToList())
        //     {
        //         if (ButtonDict[item])
        //         {
        //             item.interactable = true;
        //         }
        //         else
        //         {
        //             item.interactable = false;
        //         }
        //     }
        // }
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = levelsSO.openedLevels[i];
        }
    }
}
