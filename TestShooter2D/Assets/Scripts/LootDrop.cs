using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LootDrop : MonoBehaviour
{
   [SerializeField] GameObject lootPref;

   public void DropLootFromEnemy(GameObject gameObject)
   {
        Instantiate(lootPref, gameObject.transform.position, Quaternion.identity);
   }
}
