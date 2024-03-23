
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class GenerateInventory : MonoBehaviour
{
    public GameObject inventoryItem;
    GameObject item;
    public InventorySO inventorySO;
    public List<Button> DeleteButtons;
    void Start()
    {

        for (int i = 0; i < inventorySO.staticInventorySize; i++)
        {

            GameObject item = Instantiate(inventoryItem, gameObject.transform.position, Quaternion.identity);
            item.transform.SetParent(gameObject.transform);
        }
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            UpdateUI();
            // gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Image>().sprite = inventorySO.weapons[i].weaponImage;
            DeleteButtons.Add(gameObject.transform.GetChild(i).gameObject.transform.GetChild(1).GetComponent<Button>());
        }
    }

    public void UpdateUI()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            // if (inventorySO.weapons[i] == null)
            // {
            //     Debug.Log($"{i} Empty item");
            //     continue;
            // }
            if (inventorySO.weapons.Count > 0)
                if (inventorySO.weapons[i].isEquiped)
                {
                    gameObject.transform.GetChild(i).transform.GetChild(0).gameObject.GetComponent<Image>().sprite = inventorySO.weapons[i].weaponImage;
                }

        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < inventorySO.weapons.Count; i++)
        {
            if (inventorySO.weapons[i] == null)
            {
                Debug.Log($"{i} Empty item");
                continue;
            }
            if (inventorySO.weapons[i].isEquiped)
            {
                gameObject.transform.GetChild(i).transform.GetChild(0).gameObject.GetComponent<Image>().sprite = inventorySO.weapons[i].weaponImage;
            }
        }
    }
}
