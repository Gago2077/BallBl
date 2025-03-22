using UnityEngine;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    public int Health { get; private set; }
    [SerializeField] private TextMeshPro _healthText;

    private void Start()
    {
        Health = LevelManager.Instance.GetHealth();
        UpdateHealthText();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        UpdateHealthText();
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void UpdateHealthText()
    {
        if (_healthText != null)
        {
            _healthText.text = Health.ToString();
        }
    }
}
