using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(PlayerInputHandler))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _acceleration = 20f;
    [SerializeField] private float _jumpStrength = 5f;
    [SerializeField] private float _mass = 1f;

    private CharacterController _characterController;
    private PlayerInputHandler _playerInputHandler;
    private Vector3 _input;
    private Vector3 _velocity;
    private Vector3 _gravity;
    private float _factor;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerInputHandler = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        UpdateGravity();
        UpdateMovement();
    }

    private void UpdateGravity()
    {
        _gravity = Physics.gravity * _mass * Time.deltaTime;
        _velocity.y = _characterController.isGrounded ? -1f : _velocity.y + _gravity.y;
    }

    private void UpdateMovement()
    {
        _input = Vector3.zero;

        _input += transform.forward * _playerInputHandler.MoveInput.y;
        _input += transform.right * _playerInputHandler.MoveInput.x;
        _input = Vector3.ClampMagnitude(_input, 1f);
        _input *= _speed;

        _factor = _acceleration * Time.deltaTime;
        _velocity.x = Mathf.Lerp(_velocity.x, _input.x, _factor);
        _velocity.z = Mathf.Lerp(_velocity.z, _input.z, _factor);

        if (_playerInputHandler.IsJumping && _characterController.isGrounded)
        {
            _velocity.y += _jumpStrength;
        }

        _characterController.Move(_velocity * Time.deltaTime);
    }
}
