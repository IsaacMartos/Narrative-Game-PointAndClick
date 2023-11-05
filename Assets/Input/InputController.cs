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
    public bool click { get; private set; }

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
        controls.Gameplay.Move.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => movement = Vector2.zero;
        controls.Gameplay.Interact.performed += ctx => interact = ctx.ReadValueAsButton();
        controls.Gameplay.Interact.canceled += ctx => interact = ctx.ReadValueAsButton();
        controls.Gameplay.Click.performed += ctx => click = ctx.ReadValueAsButton();
        controls.Gameplay.Click.canceled += ctx => click = ctx.ReadValueAsButton();
    }

    #region Add & Remove Functions

    public void AddInteractFunction(Action<InputAction.CallbackContext> function)
    {
        controls.Gameplay.Interact.started += function;
    }
    public void RemoveInteractFunction(Action<InputAction.CallbackContext> function)
    {
        controls.Gameplay.Interact.started -= function;
    }
    
    public void AddClickFunction(Action<InputAction.CallbackContext> function)
    {
        controls.Gameplay.Click.started += function;
    }
    public void RemoveClickFunction(Action<InputAction.CallbackContext> function)
    {
        controls.Gameplay.Click.started -= function;
    }
    

    #endregion
    
    
}
