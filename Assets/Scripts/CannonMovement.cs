using UnityEngine;

public class CannonMovement : MonoBehaviour
{
    [SerializeField] private float _movementRange;
    [SerializeField] private float _movementSpeed;
    private Rigidbody _rb;
    private float _startX;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _startX = transform.position.x;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Move(horizontalInput);
        ClampPosition();
    }
    
    private void Move(float input)
    {
        _rb.velocity = new Vector3(input * _movementSpeed, _rb.velocity.y, _rb.velocity.z);
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
