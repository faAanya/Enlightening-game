using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryAndCollectionView : MonoBehaviour
{

    public Presenter inventoryController;

    [Header("Collection elements")]
    public GameObject weaponCollectionView;

    public List<Button> AddButtons;

    public List<GameObject> weaponCollectionElements;


    [Header("Inventory elements")]
    public GenerateInventory inventoryView;

    void Awake()
    {


        for (int i = 0; i <= weaponCollectionView.transform.childCount - 1; i++)
        {

            weaponCollectionElements.Add(weaponCollectionView.transform.GetChild(i).gameObject);
            AddButtons.Add(weaponCollectionElements[i].gameObject.transform.GetChild(3).gameObject.GetComponent<Button>());
        }

    }



}