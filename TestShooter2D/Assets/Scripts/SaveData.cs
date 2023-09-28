using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static SaveData Instance;
    [SerializeField] Player player;
    [SerializeField] InventoryManager inventoryManager;

    private void Awake() 
    {
        Instance = this;
        LoadFromJson();
    }
    public void SaveToJson()
    {
        PlayerData playerData = new PlayerData();
        playerData.maxHealth = player.maxHealth;
        playerData.currenHealth = player.currenHealth;

        InventoryData inventoryData = new InventoryData();
        inventoryData.itemId = inventoryManager.itemId;

        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.persistentDataPath + "/playerData.json", json);

        string json1 = JsonUtility.ToJson(inventoryData);
        File.WriteAllText(Application.persistentDataPath + "/inventory.json", json1);
    }


    public void LoadFromJson()
    {
       string path = Application.persistentDataPath + "/playerData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
            player.currenHealth = playerData.currenHealth;
            player.maxHealth = playerData.maxHealth;
        }

        string path1 = Application.persistentDataPath + "/inventory.json";
        if (File.Exists(path1))
        {
            string json = File.ReadAllText(path1);
            InventoryData inventoryData = JsonUtility.FromJson<InventoryData>(json);
            inventoryManager.startItemId = inventoryData.itemId;
        }
    }
}

    
[Serializable]
public class PlayerData
{
    public int maxHealth;
    public int currenHealth;
}

[Serializable]
public class InventoryData
{
    public List<int> itemId;
}
