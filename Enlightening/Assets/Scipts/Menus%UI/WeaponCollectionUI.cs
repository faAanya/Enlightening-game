using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponCollectionUI : MonoBehaviour
{
    public WeaponDataSO weaponSO;
    public TMP_Text weaponNameText;
    public Image weaponImage;
    void Start()
    {
        weaponNameText.text = weaponSO.weaponName;
        weaponImage.sprite = weaponSO.weaponImage;

    }

}
