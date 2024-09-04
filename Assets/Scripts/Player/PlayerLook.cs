using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerLook : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Transform _mainCamera;

    [Header("Parameters")]
    [SerializeField] private float _sensitivity = 3f;

    private PlayerInputHandler _playerInputHandler;
    private Vector2 _look;
    private float _sensitivityMultiplier = 0.1f;

    private void Awake()
    {
        _playerInputHandler = GetComponent<PlayerInputHandler>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        UpdateLook();
    }

    private void UpdateLook()
    {
        _look.x += _playerInputHandler.LookInput.x * _sensitivity * _sensitivityMultiplier;
        _look.y += _playerInputHandler.LookInput.y * _sensitivity * _sensitivityMultiplier;

        _look.y = Mathf.Clamp(_look.y, -89f, 89f);

        _mainCamera.transform.localRotation = Quaternion.Euler(-_look.y, 0f, 0f);
        transform.localRotation = Quaternion.Euler(0f, _look.x, 0f);
    }
}
