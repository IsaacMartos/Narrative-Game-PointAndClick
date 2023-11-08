using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;
    public GameObject Pointer;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        MoveMouse();
    }

    public void MoveMouse()
    {
        //pointer to mouse position
        if (GameManager.Instance.state == GameManager.GameState.Dialogue) return;
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        Pointer.transform.position = mouseWorldPos;
        
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started || GameManager.Instance.itemManager.GetInteracting()) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        if (!rayHit.collider.GetComponent<Item>()) return;
        if (GameManager.Instance.state == GameManager.GameState.Dialogue) return;
        var x = rayHit.collider.gameObject.GetComponent<Item>();
        x.ShowDescription();
        x.ShowOutline(false);
    }
    
}
