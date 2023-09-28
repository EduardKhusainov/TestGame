using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    [Header("Only gameplay")]
    public int id;
    public ItemType itemType;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Only UI")]
    public bool IsStackable = true;

    [Header("Both")]
    public Sprite image;
    public int count;
}
public enum ItemType
{
    Helmet,
    Weapon,
    Bullet
}

 
