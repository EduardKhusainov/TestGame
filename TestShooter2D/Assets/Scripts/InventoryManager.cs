using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    [SerializeField] InventortyCell[] inventortyCells;
    [SerializeField] GameObject inventoryItemPrefab;
    [SerializeField] SaveData saveData;
    [SerializeField] Item[] items;
    public List<int> itemId;
    public List<int> startItemId;
    private void Awake()
    {
        instance = this;
        saveData.LoadFromJson();
    }

    private void Start() 
    {
        foreach(int i in startItemId)
        {
           Item item = items[i];
           AddItem(item);
        }    
        itemId = startItemId;
    }
    public void AddItem(Item item)
    {
        int itemID = item.id;
        for(int i = 0; i < inventortyCells.Length; i++)
        {
            InventortyCell cell = inventortyCells[i];
            InventoryItem itemInCell = cell.GetComponentInChildren<InventoryItem>();
            if(itemInCell != null && itemInCell.item == item && itemInCell.count < 10 && itemInCell.item.IsStackable)
            {
                itemInCell.count++;
                itemInCell.RefreshCount();
                itemId.Add(itemID);
                saveData.SaveToJson();
                return;
            }
        }


        for(int i = 0; i < inventortyCells.Length; i++)
        {
            InventortyCell cell = inventortyCells[i];
            InventoryItem itemInCell = cell.GetComponentInChildren<InventoryItem>();
            if(itemInCell == null)
            {
                SpawnNewItem(item, cell);

                itemId.Add(itemID);
                saveData.SaveToJson();
                return;
            }
        }
        Debug.Log("Not Added");
        return;
    }

    public void SpawnNewItem(Item item, InventortyCell cell)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, cell.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

}
