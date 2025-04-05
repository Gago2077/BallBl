using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] private float _spawnRate = 0.5f;

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _zoneBottom;
    [SerializeField] private Transform _zoneLeftBorder;
    [SerializeField] private Transform _zoneRightBorder;
    [SerializeField] private Transform _zoneTopBorder;

    private float _spawnTimer = 0f;
    private void Update()
    {
        if(_spawnTimer > _spawnRate && Random.Range(0,2) > 0)
        {
            SpawnEnemy();
        }
        _spawnTimer += Time.deltaTime;
    }
    private void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(_zoneLeftBorder.position.x, _zoneRightBorder.position.x),
            Random.Range(_zoneBottom.position.y, _zoneTopBorder.position.y),
            0f
        );
        GameObject enemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
        
        _spawnTimer = 0f;
    }
}
