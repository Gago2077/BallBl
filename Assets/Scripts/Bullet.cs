using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

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
