using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private Rigidbody2D _rb; 
   public float speed = 5;
   public Vector2 startPos;
   public Vector2 currentPos;
   public FixedJoystick fixedJoystick;
   private float _twoVectorsSum;
   Vector2 moveDir;
   [SerializeField] InventoryManager inventoryManager;

   private void Start() 
   {
        startPos = transform.position; 
        currentPos = startPos;
        _rb = GetComponent<Rigidbody2D>();
   }

    private void FixedUpdate() 
    {
        _rb.MovePosition(_rb.position + moveDir * speed * Time.deltaTime);
    }
   private void Update() 
   {
        Move();
   }

    public void Move()
    {
        moveDir.x = fixedJoystick.Horizontal;
        moveDir.y = fixedJoystick.Vertical;
        _twoVectorsSum = fixedJoystick.Horizontal + fixedJoystick.Vertical;
        if(moveDir.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if(moveDir.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
