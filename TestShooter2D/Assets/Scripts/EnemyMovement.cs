using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D _rb;
    GameObject target;
    public float speed;
    public float currentSpeed;
    public float walkSpeed;
    public bool canMove;
    Vector2 startPos;
    Vector2 targetPos;
    float timer = 10;
     Vector2 moveDir;
    private void Start() 
    {
        _rb = GetComponent<Rigidbody2D>();
        currentSpeed = speed;
    }
    private void FixedUpdate() 
    {
        if(canMove)
        {
          _rb.MovePosition(_rb.position + moveDir * speed * Time.deltaTime);
        }    
    }
    void Update()
    {
        if(canMove)
        {
            MoveToTarget();
        }
        if(!canMove )
        {
            IdolWalking();
        }
    }

    private void MoveToTarget()
    {
            speed = currentSpeed;
            moveDir = target.transform.position - transform.position;
            moveDir.Normalize();
            if(transform.position.x > target.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
    }

    private void IdolWalking()
    {
          timer -= Time.deltaTime;
            if(timer > 8)
            {
                walkSpeed = speed /2;
                _rb.MovePosition(_rb.position + new Vector2(1, 0) * walkSpeed * Time.deltaTime);
                if(walkSpeed > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
            }
            if(timer <= 0)
            {
                timer = 10;
                speed *= -1;
            }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            target = other.gameObject;
            canMove = true;
        }    
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            startPos = transform.position;
            canMove = false;
        }   
    }
}
