using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponCollectionUI : MonoBehaviour
{
    public WeaponDataSO weaponSO;
    public TMP_Text weaponNameText;
    public TMP_Text weaponCostText;
    public Image weaponImage;
    void Start()
    {
        weaponCostText.text = $"{weaponSO.cost} orbs.";
        weaponNameText.text = weaponSO.weaponName;
        weaponImage.sprite = weaponSO.weaponImage;

    }

}
