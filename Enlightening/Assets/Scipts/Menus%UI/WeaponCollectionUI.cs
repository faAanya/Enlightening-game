using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponCollectionUI : MonoBehaviour
{
    public WeaponDataSO weaponSO;
    public TMP_Text weaponNameText;
    public TMP_Text weaponCostText;
    public Image weaponImage;

    public Button buyButton, addButton;
    void Start()
    {
        buyButton.gameObject.SetActive(!weaponSO.isOpened);

        weaponCostText.text = $"{weaponSO.cost} orbs.";
        weaponNameText.text = weaponSO.weaponName;
        weaponImage.sprite = weaponSO.weaponImage;

    }

}
