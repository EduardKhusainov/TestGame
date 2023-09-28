using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
   public int maxHealth;
   public int currenHealth;
   [SerializeField] HealthBar healthBar;
   [SerializeField] GameObject weapon;
   public bool canShoot;

   private void Start() 
   {
        if(currenHealth == 0)
        {
            currenHealth = maxHealth; 
            healthBar.SetHealthValue(currenHealth, maxHealth);
        }
        else
        {
            healthBar.SetHealthValue(currenHealth, maxHealth);
        }
   }
     public void TakeDamage()
    {
        currenHealth--;
        healthBar.SetHealthValue(currenHealth, maxHealth);
        if(currenHealth <=0)
        {
            Destroy(gameObject);
            SceneLoader.instance.ReastartLevel();
        }

        SaveData.Instance.SaveToJson();
    }

   private void OnTriggerEnter2D(Collider2D other) 
    {
        IDamagable idamagable = other.gameObject.GetComponent<IDamagable>();
        Loot loot = other.gameObject.GetComponent<Loot>();
        if(idamagable != null)
        {
            weapon.SetActive(true);
            canShoot = true;
        } 
        if(loot != null)
        {
            if(loot.item.itemType == ItemType.Weapon)
            {
                SpriteRenderer sr = loot.GetComponent<SpriteRenderer>();
                SpriteRenderer srWeapon = weapon.gameObject.GetComponent<SpriteRenderer>();
                srWeapon.sprite = sr.sprite;
            }
            if(loot.item.itemType == ItemType.Helmet)
            {
                TakeHeal();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        IDamagable idamagable = other.gameObject.GetComponent<IDamagable>();
        if(idamagable != null)
        {
            weapon.SetActive(false);
            canShoot = false;
        }     
    }

    public void TakeHeal()
    {
        currenHealth++;
        if(currenHealth > maxHealth)
        {
            maxHealth++;
        }
        healthBar.SetHealthValue(currenHealth, maxHealth);
    }
}
