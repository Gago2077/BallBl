using UnityEngine;

public class CannonRotation : MonoBehaviour
{
    [SerializeField] private float _rotationX = 45f;
    [SerializeField] private float _rotationY = 90f;
    [SerializeField] private float _mouseSensitivity;

    private Vector3 _currentRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _currentRotation = transform.localEulerAngles;
    }

    private void Update()
    {
        float mouseInputX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        float mouseInputY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

        Rotate(mouseInputX, mouseInputY);
    }

    private void Rotate(float mouseX, float mouseY)
    {
        _currentRotation.y += mouseX;
        _currentRotation.x -= mouseY;

        _currentRotation.x = Mathf.Clamp(_currentRotation.x, -_rotationX, _rotationX);
        _currentRotation.y = Mathf.Clamp(_currentRotation.y, -_rotationY, _rotationY);

        transform.localRotation = Quaternion.Euler(_currentRotation);
    }
}
