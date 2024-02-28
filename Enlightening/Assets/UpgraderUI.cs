using System;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgraderUI : MonoBehaviour
{
    public UpgradesClass upgradesClass;

    public Canvas canvas;
    public TMP_Text[] upgradesText;

    public Button[] buttons;

    void Start()
    {
        upgradesClass = gameObject.GetComponent<UpgradesClass>();
        canvas.gameObject.SetActive(false);
    }
    public void GenerateUI()
    {
        for (int i = 0; i < upgradesText.Length; i++)
        {
            int playerIndexUpgrade = 0, weaponIndexUpgrade = 0, upgradeToOpen = 0, randomWeaponToUpgrade = 0;
            float playerModifierUpgrade = 0, weaponModifierUpgrade = 0;
            System.Random random = new System.Random();
            int t = random.Next(0, upgradesClass.upgrades.Length + 1); //generate random upgrade

            if (t == upgradesClass.upgrades.Length)
            {
                playerIndexUpgrade = random.Next(0, 2);
                playerModifierUpgrade = (float)random.NextDouble(); //generate random player characteristic to change and modifier
                upgradesText[i].text = upgradesClass.ChangePlayerCharacteristicsText(playerIndexUpgrade, playerModifierUpgrade);
            }
            else
            {
                weaponIndexUpgrade = random.Next(0, 4);
                weaponModifierUpgrade = (float)random.NextDouble(); //generate random weapon characteristic to change and modifier

                upgradeToOpen = random.Next(0, upgradesClass.upgrades.Length);
                randomWeaponToUpgrade = random.Next(0, upgradesClass.weapons.Count);

                upgradesText[i].text = upgradesClass.upgradesTexts[upgradeToOpen]
                    (upgradesClass.weapons[randomWeaponToUpgrade], weaponIndexUpgrade, weaponModifierUpgrade);
            }
            buttons[i].onClick.AddListener(() => upgradesClass.GenerateUpdate(t, playerIndexUpgrade, playerModifierUpgrade, weaponIndexUpgrade, weaponModifierUpgrade, upgradeToOpen, randomWeaponToUpgrade));
        }


    }

}
