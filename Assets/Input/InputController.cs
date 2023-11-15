using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public PlayerInput controls { get; private set; }
    public Vector2 movement { get; private set; }
    public bool interact { get; private set; }
    public bool submit { get; private set; }
    public bool click { get; private set; }

    private static InputController instance;

    public static InputController GetInstance()
    {
        return instance;
    }

    private void OnEnable()
    {
        controls = controls ?? new PlayerInput();
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Awake()
    {
        controls = controls ?? new PlayerInput();
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        instance = this;
    }

    #region Functions
    
    public void MovePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            movement = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            movement = context.ReadValue<Vector2>();
        } 
    }

    public void InteractButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interact = true;
        }
        else if (context.canceled)
        {
            interact = false;
        }
    }
    
    public void SubmitButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            submit = true;
        }
        else if (context.canceled)
        {
            submit = false;
        }
    }

    #endregion

    #region GetValues

    public bool GetInteractPressed() 
    {
        bool result = interact;
        interact = false;
        return result;
    }

    public bool GetSubmitPressed() 
    {
        bool result = submit;
        submit = false;
        return result;
    }
    
    public Vector2 GetMoveDirection() 
    {
        return movement;
    }
    

    #endregion
    
}
