using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presenter : MonoBehaviour
{

    public InventorySO inventorySO;
    public bool canAddWeapon;

    public static Action<WeaponDataSO> OnAddButtonClick;
    public static Action<int> OnDeleteButtonClick;

    public InventoryAndCollectionView inventoryAndCollectionView;

    void OnEnable()
    {
        OnAddButtonClick += AddWeaponToInventory;
        OnDeleteButtonClick += DeleteWeaponFromInventory;
    }
    void OnDisable()
    {
        OnAddButtonClick -= AddWeaponToInventory;
        OnDeleteButtonClick -= DeleteWeaponFromInventory;
    }

    public void AddWeaponToInventory(WeaponDataSO inventoryItem)
    {
        if (canAddWeapon)
        {
            inventoryItem.isEquiped = true;
            inventorySO.weapons.Add(inventoryItem);
        }
        else
        {
            return;
        }

    }
    public void DeleteWeaponFromInventory(int index)
    {

        inventorySO.weapons.RemoveAt(index);
    }

    public void Start()
    {

        if (inventorySO.weapons.Count <= inventorySO.staticInventorySize - 1)
        {
            canAddWeapon = true;
        }
        else
        {
            canAddWeapon = false;
        }
        for (int i = 0; i <= inventoryAndCollectionView.weaponCollectionElements.Count - 1; i++)
        {
            Debug.Log("Start");
            int tmp = i;
            inventoryAndCollectionView.AddButtons[i].onClick.AddListener(() =>
        {

            AddWeaponToInventory(inventoryAndCollectionView.weaponCollectionElements[tmp].GetComponent<WeaponCollectionUI>().weaponSO);
            inventoryAndCollectionView.inventoryView.UpdateUI();
            //OnAddButtonClick.Invoke(inventoryAndCollectionView.weaponCollectionElements[i].GetComponent<WeaponCollectionUI>().weaponSO);
        });
        }

        for (int i = 0; i <= inventoryAndCollectionView.inventoryView.DeleteButtons.Count - 1; i++)
        {
            int tmp = i;
            inventoryAndCollectionView.inventoryView.DeleteButtons[i].onClick.AddListener(() =>
            {
                DeleteWeaponFromInventory(tmp);
                inventoryAndCollectionView.inventoryView.UpdateUI();
            });
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (inventorySO.weapons.Count <= inventorySO.staticInventorySize - 1)
        {
            canAddWeapon = true;
        }
        else
        {
            canAddWeapon = false;
        }
        Debug.Log(canAddWeapon);
    }
}
