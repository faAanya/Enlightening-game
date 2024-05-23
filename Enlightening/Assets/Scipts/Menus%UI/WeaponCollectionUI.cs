using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
public class WeaponCollectionUI : MonoBehaviour
{
    public WeaponDataSO weaponSO;
    public TMP_Text weaponNameText;
    //private LocalizeStringEvent weaponNameLocalizeString;
    public TMP_Text weaponCostText;
    public TMP_Text weaponValuteText;
    public Image weaponImage;

    public Button buyButton, addButton;
    void Start()
    {
        buyButton.gameObject.SetActive(!weaponSO.isOpened);

        weaponCostText.text = $"{weaponSO.cost}";

        // weaponNameLocalizeString.StringReference = weaponSO.nameKey;
        weaponNameText.text = weaponSO.nameKey.GetLocalizedString();
        weaponImage.sprite = weaponSO.weaponImage;

    }

}
