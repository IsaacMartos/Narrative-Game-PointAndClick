using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefinitivePlayerMovement : MonoBehaviour
{
    public SpriteRenderer sprite;
    private Rigidbody2D rb;
    public float speed = 100;
    private float currentSpeed;
    [HideInInspector] public bool canMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
    }
    
    private void FixedUpdate()
    {
        if (GameManager.Instance.state == GameManager.GameState.Dialogue ||
            GameManager.Instance.state == GameManager.GameState.Description)
        {
            Stop();
            return;
        }
        
        HandleHorizontalMovement();
    }

    private void HandleHorizontalMovement()
    {
        Vector2 moveDirection = InputController.GetInstance().GetMoveDirection();
        rb.velocity = new Vector2(moveDirection.x * currentSpeed, rb.velocity.y);
        MovePlayer(moveDirection);
        if (moveDirection.x>0)
        {
            sprite.flipX = false;
        }
        if (moveDirection.x<0)
        {
            sprite.flipX = true;
        }
    }
    
    private void MovePlayer(Vector3 direction)
    {
        currentSpeed = Mathf.Lerp(currentSpeed, speed, Time.deltaTime * 100);
    }
    
    public void Stop()
    {
        canMove = false;
        rb.velocity = Vector3.zero;
    }
   
}
