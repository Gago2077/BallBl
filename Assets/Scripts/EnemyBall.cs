using UnityEngine;

public class EnemyBall : MonoBehaviour
{
    [SerializeField] private float _speedOnSpawn;
    private Rigidbody _rb;
    private HealthSystem _healthSystem;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _healthSystem = GetComponent<HealthSystem>();

        _rb.AddForce(Vector3.back * _speedOnSpawn, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision detected with: {collision.gameObject.name}");

        if (collision.gameObject.TryGetComponent<IProjectile>(out IProjectile projectile))
        {
            _healthSystem.TakeDamage(projectile.Damage);
            Destroy(collision.gameObject);
        }
    }
}
