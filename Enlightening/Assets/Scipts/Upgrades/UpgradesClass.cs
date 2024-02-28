using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Unity.VisualScripting;
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


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvas.gameObject.SetActive(true);
            upgraderUI.GenerateUI();
        }
    }

    public void GenerateUpdate(int t, int playerIndexUpgrade, float playerModifierUpgrade, int weaponIndexUpgrade, float weaponModifierUpgrade, int upgradeToOpen, int randomWeaponToUpgrade)
    {
        Debug.Log("Entered button");
        if (t == upgrades.Length)
        {
            ChangePlayerCharacteristics(playerController, playerIndexUpgrade, playerModifierUpgrade);
        }
        else
        {
            upgrades[upgradeToOpen](weapons[randomWeaponToUpgrade], weaponIndexUpgrade, weaponModifierUpgrade);
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
        switch (index)
        {
            case 0:
                return $" player health + {modifier}%";
                break;
            case 1:
                return $" player speed + {modifier}%";
                break;
        }
        return "Mistake";
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

        switch (index)
        {
            case 0:
                return $" {weapon.name} damage + {modifier}%";
                break;
            case 1:

                return $" {weapon.name} duration + {modifier}%";
                break;
            case 2:

                return $" {weapon.name} cooldown + {modifier}%";
                break;
            case 3:
                return $" {weapon.name} number + 1";
                break;
        }
        return "Mistake";
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
