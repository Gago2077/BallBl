using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyBall : MonoBehaviour
{
    public int Health;
    [SerializeField] private float _speedOnSpawn;
    private TextMeshPro _healthText;
    private GameObject _player;

    private void Start()
    {
        Health = LevelManager.Instance.GetHealth();
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.back * _speedOnSpawn, ForceMode.Impulse);
        _healthText = GetComponentInChildren<TextMeshPro>();
        _player = GameObject.Find("Player");

    }
    private void Update()
    {
        UpdateHealthText();
        DieCheck();
    }
    private void UpdateHealthText()
    {
        _healthText.text = Health.ToString();
        
    }
    private void DieCheck()
    {
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Collision detected with: {other.gameObject.name}");

        if (other.gameObject.CompareTag("Projectile"))
        {
            Health -= _player.GetComponent<Firing>()._projectileDamage;
            Destroy(other.gameObject);
        }
    }
}

