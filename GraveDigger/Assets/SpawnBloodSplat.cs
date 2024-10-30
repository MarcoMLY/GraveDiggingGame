using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBloodSplat : MonoBehaviour
{
    [SerializeField] private GameObject _bloodSplat;
    
    public void SpawnSplat(Transform attacker)
    {
        Vector2 direction = transform.position - attacker.position;
        Transform bloodSplat = Instantiate(_bloodSplat, transform.position, Quaternion.identity).transform;
        bloodSplat.up = direction.normalized;
    }
}