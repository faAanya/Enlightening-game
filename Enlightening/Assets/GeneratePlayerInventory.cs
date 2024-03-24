using UnityEngine;
using UnityEngine.UI;

public class GeneratePlayerInventory : MonoBehaviour
{

    public InventorySO inventorySO;
    public GameObject inventoryItem;
    public Sprite emptySprite;
    void Awake()
    {
        for (int i = 0; i < inventorySO.staticInventorySize; i++)
        {
            GameObject item = Instantiate(inventoryItem, gameObject.transform.position, Quaternion.identity);
            item.transform.SetParent(gameObject.transform);
        }
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            UpdateUI();
        }
    }
    public void UpdateUI()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).transform.GetChild(0).gameObject.GetComponent<Image>().sprite = emptySprite;
            if (inventorySO.weapons.Count <= gameObject.transform.childCount)
            {
                for (int j = 0; j < inventorySO.weapons.Count; j++)
                {
                    gameObject.transform.GetChild(j).transform.GetChild(0).gameObject.GetComponent<Image>().sprite = inventorySO.weapons[j].weaponImage;
                }
            }
        }
    }

}
