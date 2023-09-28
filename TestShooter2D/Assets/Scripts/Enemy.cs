using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] int maxHealth = 5;
    public int currenHealth;
    [SerializeField] LootDrop lootDrop;
    [SerializeField] HealthBar healthBar;
    [SerializeField] ParticleSystem zombiSplash;

    private void Start() 
    {
        currenHealth = maxHealth;    
    }

    public void TakeDamage()
    {
        currenHealth--;
        healthBar.SetHealthValue(currenHealth, maxHealth);
        if(currenHealth <=0)
        {
            Destroy(gameObject);
            lootDrop.DropLootFromEnemy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            MiliAttack();
            StartCoroutine(Attack());
        }    
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StopCoroutine(Attack());
        }    
    }


    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(3);
        MiliAttack();
        StartCoroutine(Attack());
    }

    private void MiliAttack()
    {
        Vector2 circleCenter = transform.position;

        int radius = 2;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(circleCenter, radius);
        foreach (Collider2D collider in colliders)
        {
            if(collider.CompareTag("Player"))
            {
                IDamagable damagable = collider.GetComponent<IDamagable>();
                if(damagable != null)
                {
                    damagable.TakeDamage();
                    zombiSplash.Play();
                }
            }
        }
    }
}
