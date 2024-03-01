using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.XR;

public class UpgradesClass : MonoBehaviour
{

    #region Controllers
    private PlayerController playerController;
    private PlayerWeaponController weaponController;
    #endregion

    #region Stuff to Upgrade

    [HideInInspector]
    public List<float> playerCharacterstics;

    public List<WeaponClass> weapons = new List<WeaponClass>();

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
    private void Start()
    {
        upgraderUI = gameObject.GetComponent<UpgraderUI>();

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        weaponController = GameObject.FindGameObjectWithTag("WeaponController").GetComponent<PlayerWeaponController>();


        for (int i = 0; i < weaponController.weaponsGameObjects.Length; i++)
        {
            weapons.Add(weaponController.weaponsGameObjects[i].GetComponent<WeaponClass>());
        }

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
            //SetWeaponAvaliable(weapons[randomWeaponToUpgrade], upgradeToOpen, weaponModifierUpgrade);

            //ChangeRandomCharacteristicOfRandomWeaponText(weapons[randomWeaponToUpgrade], upgradeToOpen, weaponModifierUpgrade);

            // upgrades[upgradeToOpen](weapons[randomWeaponToUpgrade], upgradeToOpen, weaponModifierUpgrade);
        }
    }

    public void ChangePlayerCharacteristics(PlayerController player, int index, float modifier)
    {
        switch (index)
        {
            case 0:
                player.health = player.health + player.health * modifier;
                break;
            case 1:
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
                str = $" Player health + {modifier}%";
                break;
            case 1:
                str = $" Player speed + {modifier}%";
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
                str = $" {weapon.name} damage + {modifier}%";
                break;
            case 1:

                str = $" {weapon.name} duration + {modifier}%";
                break;
            case 2:

                str = $" {weapon.name} cooldown + {modifier}%";
                break;
            case 3:
                str = $" {weapon.name} number + 1";
                break;
        }
        return str;
    }

    public void SetWeaponAvaliable(WeaponClass weapon, int index, float modifier)
    {
        weapon.isAvaliable = true;
    }

    public string SetWeaponAvaliableText(WeaponClass weapon, int index, float modifier)
    {
        return $"Avaliable {weapon.name}";
    }

}
