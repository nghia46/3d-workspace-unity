using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [Header("Player Pops")]
    [SerializeField]private LayerMask groundMask;
    [SerializeField][Range(1,20)]private float speed = 12f;
    [SerializeField][Range(1,10)]private float jumpHeight = 2f;
    private CharacterController _controller;
    private Transform _groundCheck;
    private bool _isGrounded;
    private const float Gravity = -18.32f;
    private Vector3 _velocity;
    private const float GroundDistance = .1f;

    private void Awake()
    {
        _groundCheck = GameObject.Find("GroundCheck").transform;
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, GroundDistance, groundMask);
        print(_isGrounded);
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        var xMove = Input.GetAxisRaw("Horizontal");
        var yMove = Input.GetAxisRaw("Vertical");
    
        var move = transform.right * xMove + transform.forward * yMove;
        
        _controller.Move(move * (speed * Time.deltaTime));

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * Gravity);
        }
        _velocity.y += Gravity * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, transform.GetChild(1).rotation.eulerAngles.y, 0);
        _controller.Move(_velocity * Time.deltaTime);
    }
}