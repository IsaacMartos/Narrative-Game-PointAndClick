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
        //pointer to mouse position
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        Pointer.transform.position = mouseWorldPos;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        var x = rayHit.collider.gameObject.GetComponent<Item>();

        if (!x.GetComponent<Item>()) return;

        x.ShowDescription();
        x.ShowOutline(false);
    }
    
}
