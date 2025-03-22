using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    [SerializeField] private float _fireRate;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private int _projectileSpeed;
    public int _projectileDamage;

    private float cooldownTimer = 50;
    private void Update()
    {
        if (Input.GetButton("Fire1") && cooldownTimer > _fireRate)
        {
            Fire();
            
            cooldownTimer = 0;
        }
        cooldownTimer += Time.deltaTime;
    }
    private void Fire()
    {
        GameObject projectile = Instantiate(_projectilePrefab, _firePoint.position, _firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(_firePoint.forward * _projectileSpeed, ForceMode.Impulse);
    }

    

}