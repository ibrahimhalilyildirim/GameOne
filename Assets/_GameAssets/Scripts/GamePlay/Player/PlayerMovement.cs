using UnityEngine;
using UnityEngine.InputSystem; // Yeni Input System kütüphanesi.

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;

    [Header("Ground Check")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] float checkRadius = 0.2f;

    private Rigidbody2D _playerRigidbody;
    private float _horizontalInput;
    private bool _isGrounded;
    

    private void Start()
    {
        // Rigidbody2D bileşenini koddan çekiyoruz.
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        _horizontalInput = 0f;
        if(Keyboard.current != null)
        {
            if(Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                _horizontalInput = -1;
            }
            if(Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                _horizontalInput = 1;
            }
        }

        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, checkRadius, _groundLayer);

        if(Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame && _isGrounded)
        {
            _playerRigidbody.linearVelocity = new Vector2(_playerRigidbody.linearVelocity.x, _jumpForce);
        }
    }

    private void FixedUpdate()
    {
        _playerRigidbody.linearVelocity = new Vector2(_horizontalInput * _moveSpeed, _playerRigidbody.linearVelocity.y);
    }

}
