
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Localization.Settings;

[System.Serializable]
public class LocalizationS : MonoBehaviour, IDataPersistence
{
    public static LocalizationS localizationSetter;
    public int localisation;
    private void Start()
    {
        // StartCoroutine(SetLocale(localisation));
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localisation];
        Debug.Log(LocalizationSettings.SelectedLocale);
    }
    public void ChangeLocale()
    {
        if (localisation == 1) //English to Russian
        {
            localisation = 0;
        }
        else
        {
            localisation = 1; //Russian to English
        }
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localisation];

    }
    public IEnumerator SetLocale(int localeID)
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
    }

    public void LoadData(GameData gameData)
    {
        localisation = gameData.localisationLang;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.localisationLang = localisation;
    }
}
