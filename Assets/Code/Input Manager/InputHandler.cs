using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;
    GameObject pointer;
    GameObject player;
    private bool interactionPressed = false;

    private static InputHandler instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Input manager on this scene");
        }

        player = GameObject.FindGameObjectWithTag("Player");
        
        instance = this;
    }

    private void Start()
    {
        pointer = Singleton.Instance.Pointer;
        _mainCamera = Camera.main;
    }

    public static InputHandler GetInstance()
    {
        return instance;
    }

    void Update()
    {
        //pointer to mouse position
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        pointer.transform.position = mouseWorldPos;
        Debug.Log(_mainCamera);

    }

    public void GetCameraAllRight()
    {
        Debug.Log("Aignada la camara nueva");
        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        if (rayHit.collider.GetComponent<Item>())
        {
            if (GameManager.Instance.state == GameManager.GameState.Description) return;
            var x = rayHit.collider.gameObject.GetComponent<Item>();
            x.ShowDescription();
            x.ShowOutline(false);
        }
        if (rayHit.collider.GetComponent<ClickableObject>())
        {
            if (GameManager.Instance.state == GameManager.GameState.Description) return;
            var x = rayHit.collider.gameObject.GetComponent<ClickableObject>();
            x.Action();
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactionPressed = true;
        }
        else if (context.canceled)
        {
            interactionPressed = false;
        }
    }
}
