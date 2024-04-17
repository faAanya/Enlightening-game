using System.Collections.Generic;
using UnityEngine;

public class UpgradesClass : MonoBehaviour
{

    #region Controllers
    private PlayerController playerController;
    public PlayerWeaponController weaponController;
    #endregion

    #region Stuff to Upgrade

    [HideInInspector]
    public List<float> playerCharacterstics;

    public List<WeaponClass> weapons = new List<WeaponClass>();
    public List<GameObject> weaponsGO = new List<GameObject>();

    #endregion

    #region Upgrade delegates

    public delegate void Upgrades(WeaponClass weaponClass, int index, float modifier);
    public delegate string UpgradesText(WeaponClass weapon, int index, float modifier);
    public Upgrades[] upgrades;
    public UpgradesText[] upgradesTexts;

    #endregion


    #region UI

    private UpgraderUI upgraderUI;
    public GameObject canvas;
    #endregion
    private void Awake()
    {
        upgraderUI = gameObject.GetComponent<UpgraderUI>();

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //weaponController = GameObject.FindGameObjectWithTag("WeaponController").GetComponent<PlayerWeaponController>();


        // for (int i = 0; i < weaponController.weaponsGameObjects.Length; i++)
        // {
        //     weapons.Add(weaponController.weaponsGameObjects[i].GetComponent<WeaponClass>());
        // }

        playerCharacterstics = new List<float> { playerController.health, playerController.movementSpeed };

        upgrades = new Upgrades[]{
            ChangeRandomCharacteristicOfRandomWeapon, SetWeaponAvaliable
        };

        upgradesTexts = new UpgradesText[]{
            ChangeRandomCharacteristicOfRandomWeaponText, SetWeaponAvaliableText
        };

    }

    public void ShowUI()
    {
        canvas.gameObject.SetActive(true);
        upgraderUI.GenerateUI();
    }


    public void GenerateUpdate(int t, int playerIndexUpgrade, float playerModifierUpgrade, float weaponModifierUpgrade, int upgradeToOpen, int randomWeaponToUpgrade)
    {
        Debug.Log($"Entered button {t} {upgradeToOpen} {weaponModifierUpgrade} {upgradeToOpen} {randomWeaponToUpgrade} {weapons[randomWeaponToUpgrade].name}");
        if (t == upgrades.Length)
        {
            ChangePlayerCharacteristics(playerController, playerIndexUpgrade, playerModifierUpgrade);
        }
        else
        {

            upgrades[upgradeToOpen](weapons[randomWeaponToUpgrade], upgradeToOpen, weaponModifierUpgrade);

        }
    }

    public void ChangePlayerCharacteristics(PlayerController player, int index, float modifier)
    {
        switch (index)
        {
            case 0:
                player.health = player.health + player.health * modifier;
                SliderController.slider.maxValue = player.health;
                break;
            case 1:
                if (player.movementSpeed >= 20)
                {
                    ChangePlayerCharacteristics(player, 0, .2f);
                }
                player.movementSpeed = player.movementSpeed + player.movementSpeed * modifier;
                break;
        }
    }


    public string ChangePlayerCharacteristicsText(int index, float modifier)
    {
        string str = "";
        switch (index)
        {
            case 0:
                str = $" Player health + {System.Math.Round(modifier, 2) * 100}%";
                break;
            case 1:
                str = $" Player speed + {System.Math.Round(modifier, 2) * 100}%";
                break;
        }
        return str;
    }


    public void ChangeRandomCharacteristicOfRandomWeapon(WeaponClass weapon, int index, float modifier)
    {
        switch (index)
        {
            case 0:
                weapon.damage = weapon.damage + weapon.damage * modifier;
                break;
            case 1:
                weapon.duration = weapon.duration + weapon.duration * modifier;
                break;
            case 2:
                weapon.coolDown = weapon.coolDown - weapon.coolDown * modifier;
                break;
            case 3:
                weapon.number++;
                break;
        }
    }

    public string ChangeRandomCharacteristicOfRandomWeaponText(WeaponClass weapon, int index, float modifier)
    {
        string str = "";
        switch (index)
        {
            case 0:
                str = $" {weapon.weaponName} damage + {System.Math.Round(modifier, 2) * 100}%";
                break;
            case 1:

                str = $" {weapon.weaponName} duration + {System.Math.Round(modifier, 2) * 100}%";
                break;
            case 2:

                str = $" {weapon.weaponName} cooldown + {System.Math.Round(modifier, 2) * 100}%";
                break;
            case 3:
                str = $" {weapon.weaponName} number + 1";
                break;
        }
        return str;
    }

    public void SetWeaponAvaliable(WeaponClass weapon, int index, float modifier)
    {
        weapon.enabled = true;
    }

    public string SetWeaponAvaliableText(WeaponClass weapon, int index, float modifier)
    {
        return $"Avaliable {weapon.weaponName}";
    }

}
