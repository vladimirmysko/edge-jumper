using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpStrength = 5f;
    [SerializeField] private float _mass = 1f;

    private CharacterController _characterController;
    private Vector3 _velocity;
    private Vector3 _gravity;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
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
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        var input = new Vector3();
        input += transform.forward * y;
        input += transform.right * x;
        input = Vector3.ClampMagnitude(input, 1f);

        if (Input.GetButton("Jump") && _characterController.isGrounded)
        {
            _velocity.y += _jumpStrength;
        }

        _characterController.Move((input * _speed + _velocity) * Time.deltaTime);
    }
}
