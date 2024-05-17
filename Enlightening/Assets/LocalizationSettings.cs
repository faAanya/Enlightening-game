
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Localization.Settings;


public class LocalizationS : MonoBehaviour
{

    private void Start()
    {
        int ID = PlayerPrefs.GetInt("LocaleKey", 1);
        ChangeLocale(ID);
    }
    public bool isEnglish = false;
    private bool active = false;
    public void ChangeLocale(int ID)
    {
        if (active)
        {
            return;
        }
        if (isEnglish)
        {
            ID = 1;
            StartCoroutine(SetLocale(ID));
        }
        else
        {
            ID = 0;
            StartCoroutine(SetLocale(ID));
        }


    }
    public IEnumerator SetLocale(int localeID)
    {

        isEnglish = !isEnglish;
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        PlayerPrefs.SetInt("LocaleKey", localeID);
        active = false;
    }
}
