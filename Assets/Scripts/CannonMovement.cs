using UnityEngine;

public class CannonMovement : MonoBehaviour
{
    [SerializeField] private float _movementRange;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationX = 45f;  // Max X rotation (Up/Down)
    [SerializeField] private float _rotationY = 90f;  // Max Y rotation (Left/Right)
    [SerializeField] private float _mouseSensitivity;

    private Transform _cannon;
    private Rigidbody _rb;
    private float _startX;
    private float _horizontalInput;
    private float _mouseInputX;
    private float _mouseInputY;
    private Vector3 _currentRotation;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _cannon = transform;
        _startX = transform.position.x;
        Cursor.lockState = CursorLockMode.Locked;

        _currentRotation = _cannon.localEulerAngles;
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _mouseInputX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        _mouseInputY = Input.GetAxis("Mouse Y") * _mouseSensitivity;
        ApplyMovement();
        ClampPosition();
        CannonRotation();
    }

    

    private void ApplyMovement()
    {
        _rb.velocity = new Vector3(_horizontalInput * _movementSpeed, _rb.velocity.y, _rb.velocity.z);
    }

    private void CannonRotation()
    {
        _currentRotation.y += _mouseInputX; // Rotate left/right
        _currentRotation.x -= _mouseInputY; // Rotate up/down

        // Clamp rotation to avoid flipping
        _currentRotation.x = Mathf.Clamp(_currentRotation.x, -_rotationX, _rotationX);
        _currentRotation.y = Mathf.Clamp(_currentRotation.y, -_rotationY, _rotationY);

        _cannon.localRotation = Quaternion.Euler(_currentRotation);
    }

    private void ClampPosition()
    {
        Vector3 currentPos = _rb.position;
        float clampedX = Mathf.Clamp(currentPos.x, _startX - _movementRange, _startX + _movementRange);

        if (!Mathf.Approximately(currentPos.x, clampedX))
        {
            _rb.position = new Vector3(clampedX, currentPos.y, currentPos.z);
            _rb.velocity = new Vector3(0, _rb.velocity.y, _rb.velocity.z);
        }
    }
}
