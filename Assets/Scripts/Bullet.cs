using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour, IProjectile
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private int _damage;

    public int Damage => _damage; // Implements IProjectile

    private void Start()
    {
        StartCoroutine(Vanish());
    }

    private IEnumerator Vanish()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }
}
