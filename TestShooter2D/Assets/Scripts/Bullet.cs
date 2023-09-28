using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public float speed;


    private void Update() 
    {
        Move();  
    }

    public void Move()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        var target = other.gameObject.GetComponent<IDamagable>();
        if(target != null)
        {
            target.TakeDamage();
        }
        Destroy(gameObject);
    }
}
