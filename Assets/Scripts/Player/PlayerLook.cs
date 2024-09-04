using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Transform _mainCamera;

    [Header("Parameters")]
    [SerializeField] private float _sensitivity = 3f;

    private Vector2 _look;

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
        _look.x += Input.GetAxis("Mouse X") * _sensitivity;
        _look.y += Input.GetAxis("Mouse Y") * _sensitivity;

        _look.y = Mathf.Clamp(_look.y, -89f, 89f);

        _mainCamera.transform.localRotation = Quaternion.Euler(-_look.y, 0f, 0f);
        transform.localRotation = Quaternion.Euler(0f, _look.x, 0f);
    }
}
