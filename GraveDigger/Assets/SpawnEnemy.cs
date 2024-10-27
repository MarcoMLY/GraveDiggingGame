using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _spawnTransform;

    // Start is called before the first frame update
    void Awake()
    {
        Spawn();
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(_enemy, _spawnTransform.position, Quaternion.identity);
    }
}
