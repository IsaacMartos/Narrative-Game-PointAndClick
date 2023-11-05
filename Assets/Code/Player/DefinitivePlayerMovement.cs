using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefinitivePlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 100;
    private float currentSpeed;
    [HideInInspector] public bool canMove;

    [SerializeField] private InputController input;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
    }
    
    private void Update()
    {
        if (!canMove) return;
        
        if (input.movement != Vector2.zero)
        {
            MovePlayer(input.movement);
        }
        else
        {
            currentSpeed = 0;
        }
        
        rb.velocity = input.movement.normalized * (currentSpeed * Time.deltaTime * 100f);
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
