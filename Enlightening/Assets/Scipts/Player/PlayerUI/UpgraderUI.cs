using System;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgraderUI : MonoBehaviour
{
    public UpgradesClass upgradesClass;

    public GameObject canvas;
    public TMP_Text[] upgradesText;

    public Button[] buttons;

    void Awake()
    {
        upgradesClass = gameObject.GetComponent<UpgradesClass>();
        canvas.SetActive(false);
    }
    public void GenerateUI()
    {
        for (int i = 0; i < upgradesText.Length; i++)
        {

            System.Random random = new System.Random();
            int t = random.Next(0, upgradesClass.upgrades.Length + 1); //generate random upgrade

            int playerIndexUpgrade = random.Next(0, 2), upgradeToOpen = random.Next(0, upgradesClass.upgrades.Length), randomWeaponToUpgrade = random.Next(0, upgradesClass.weapons.Count);
            float playerModifierUpgrade = (float)random.NextDouble(), weaponModifierUpgrade = (float)random.NextDouble();

            if (!upgradesClass.weapons[randomWeaponToUpgrade].isAvaliable)
            {
                upgradeToOpen = 1;
            }
            else
            {
                upgradeToOpen = 0;
            }

            if (t == upgradesClass.upgrades.Length)
            {
                upgradesText[i].text = upgradesClass.ChangePlayerCharacteristicsText(playerIndexUpgrade, playerModifierUpgrade);
            }
            else
            {
                upgradesText[i].text = upgradesClass.upgradesTexts[upgradeToOpen]
                    (upgradesClass.weapons[randomWeaponToUpgrade], upgradeToOpen, weaponModifierUpgrade);
            }
            buttons[i].onClick.AddListener(() => upgradesClass.GenerateUpdate(t, playerIndexUpgrade, playerModifierUpgrade, weaponModifierUpgrade, upgradeToOpen, randomWeaponToUpgrade));
            buttons[i].onClick.AddListener(() => canvas.SetActive(false));
        }


    }

}
