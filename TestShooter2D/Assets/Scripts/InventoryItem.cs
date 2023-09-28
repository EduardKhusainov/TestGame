using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class InventoryItem : MonoBehaviour
{
    public Item item;
    public int count = 1;
    public int id;
    public int index;
    public Text countText;
    [Header("UI")]
    public Image image;

    [SerializeField] InventoryManager inventoryManager;

    private void Start() 
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        id = item.id;
        image.sprite = newItem.image;
        RefreshCount();
    }

    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }

    public void RemoveFromList()
    {
        if(count > 1)
        {
            count--;
            RefreshCount();
            for(int i = 0; i < inventoryManager.itemId.Count; i++)
            {
                if(inventoryManager.itemId[i] == item.id)
                {
                    inventoryManager.itemId.Remove(inventoryManager.itemId[i]);

                    SaveData.Instance.SaveToJson();
                    return;
                }
            }
        }
        else
        {
            for(int i = 0; i < inventoryManager.itemId.Count; i++)
            {
                if(inventoryManager.itemId[i] == item.id)
                {
                    inventoryManager.itemId.Remove(inventoryManager.itemId[i]);
                    Destroy(gameObject);

                    SaveData.Instance.SaveToJson();
                    return;
                }
            }
        }
    }
}
