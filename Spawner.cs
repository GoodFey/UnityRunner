using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectsPool
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _secondsBetweenSpawn;

    private float _passedTime;

    private void Start()
    {
        CreateObjectsInPools(_enemyPrefab);
    }

    private void Update()
    {
        _passedTime += Time.deltaTime;

        if (_passedTime > _secondsBetweenSpawn)
        {

            if (TryGetObject(out GameObject enemy))
            {
                _passedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);

            }
        }
    }
    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }


}
