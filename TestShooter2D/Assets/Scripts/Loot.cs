using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Loot : MonoBehaviour
{
   public Item[] items;
   public Item item;
   public SpriteRenderer sr;

   private void Start() 
   {
        Initialize(); 
   }
   public void Initialize()
   {
        int randomIndex = Random.Range(0, 3);
        item = items[randomIndex];
        sr.sprite = item.image;
   }

   private void OnTriggerEnter2D(Collider2D other) 
   {
        if(other.gameObject.CompareTag("Player"))
        {
            InventoryManager.instance.AddItem(item);
            Destroy(gameObject);
        } 
   }
}
