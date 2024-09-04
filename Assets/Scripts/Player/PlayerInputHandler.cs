using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInputActions _inputActions;
    private Vector2 _moveInput;
    private Vector2 _lookInput;
    private bool _isJumping;

    public Vector2 MoveInput => _moveInput;
    public Vector2 LookInput => _lookInput;
    public bool IsJumping => _isJumping;

    private void Awake()
    {
        _inputActions = new PlayerInputActions();

        _inputActions.Player.Move.performed += context => _moveInput = context.ReadValue<Vector2>();
        _inputActions.Player.Move.canceled += context => _moveInput = Vector2.zero;

        _inputActions.Player.Look.performed += context => _lookInput = context.ReadValue<Vector2>();
        _inputActions.Player.Look.canceled += context => _lookInput = Vector2.zero;

        _inputActions.Player.Jump.performed += context => _isJumping = context.ReadValueAsButton();
        _inputActions.Player.Jump.canceled += context => _isJumping = false;
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }
}