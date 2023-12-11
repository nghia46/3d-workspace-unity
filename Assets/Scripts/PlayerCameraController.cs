using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField][Range(0.1f,10)] private float sensitivity = 2f;
    private Vector2 _rotation;
    
    private Transform _playerOrientation;
    private void Awake()
    {
        _playerOrientation = GameObject.FindGameObjectWithTag("Player").transform.GetChild(1);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        var mouseX = Input.GetAxisRaw("Mouse X");
        var mouseY = Input.GetAxisRaw("Mouse Y");
        
        var mousePos = new Vector2(mouseX, mouseY) * (Time.deltaTime * (sensitivity*100));
        _rotation.y += mousePos.x;
        _rotation.x -= mousePos.y;
        _rotation.x = Mathf.Clamp(_rotation.x, -90, 90);

        transform.rotation = Quaternion.Euler(_rotation.x,_rotation.y,0);
        _playerOrientation.rotation = Quaternion.Euler(0, _rotation.y, 0);
    }
}