using EventSystem;
using Tools;
using Unity.Collections;
using UnityEngine;
namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Pops")] [SerializeField]
        private LayerMask groundMask;

        [SerializeField] [Range(1, 20)] private float speed = 12f;
        [SerializeField] [Range(1, 10)] private float jumpHeight = 2f;
        [SerializeField] private float gravity;
        [SerializeField] private float groundDistance = .2f;
        [ReadOnly] [SerializeField] private int score;
        private CharacterController _controller;
        private Transform _groundCheck;
        private bool _isGrounded;
        private Vector3 _velocity;

        private void Awake()
        {
            _groundCheck = GameObject.Find("GroundCheck").transform;
            _controller = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            score = FindAnyObjectByType<UpdatePoint>().Score;
        }

        void Update()
        {
            
            _isGrounded = Physics.CheckSphere(_groundCheck.position, groundDistance, groundMask);
            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f;
            }

            var xMove = Input.GetAxisRaw("Horizontal");
            var yMove = Input.GetAxisRaw("Vertical");
            var move = (transform.right * xMove) + (transform.forward * yMove);
            _controller.Move(move * (speed * Time.deltaTime));
            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            _velocity.y += gravity * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, transform.GetChild(1).rotation.eulerAngles.y, 0);
            _controller.Move(_velocity * Time.deltaTime);
        }

        public void SayHello()
        {
            CustomTools.Log("Hello",CustomTools.LogColor.Yellow);
        }
        
    }
}