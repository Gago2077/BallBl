using UnityEngine;

public class FiringSystem : MonoBehaviour
{
    [SerializeField] private float _fireRate;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private int _projectileSpeed;

    private float _cooldownTimer = 0;

    private void Update()
    {
        _cooldownTimer += Time.deltaTime;
        if (Input.GetButton("Fire1") && _cooldownTimer > _fireRate)
        {
            Fire();
            _cooldownTimer = 0;
        }
    }

    private void Fire()
    {
        GameObject projectile = Instantiate(_projectilePrefab, _firePoint.position, _firePoint.rotation);
        if (projectile.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.AddForce(_firePoint.forward * _projectileSpeed, ForceMode.Impulse);
        }
    }
}
