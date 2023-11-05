using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput = null;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rb;
    public float speed = 100;

    private void Awake()
    {
        playerInput = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        playerInput.Enable();
        playerInput.Gameplay.Move.performed += OnMovementPerformed;
        playerInput.Gameplay.Move.canceled += OnMovementCancelled;

    }
    private void OnDisable()
    {
        playerInput.Disable();
        playerInput.Gameplay.Move.performed -= OnMovementPerformed;
        playerInput.Gameplay.Move.canceled -= OnMovementCancelled;
        
    }
    private void FixedUpdate()
    {
        rb.velocity = moveVector * speed * Time.deltaTime;
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
       // if(GameManager.Instance.state == GameManager.GameState.Dialogue) return;
        moveVector = context.ReadValue<Vector2>();
    }
    private void OnMovementCancelled(InputAction.CallbackContext context)
    {
       // if (GameManager.Instance.state == GameManager.GameState.Dialogue) return;
        moveVector = Vector2.zero;
    }
}
