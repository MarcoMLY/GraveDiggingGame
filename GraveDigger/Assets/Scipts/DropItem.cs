using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] private GameObject _droppedMaterial;
    [SerializeField] private float _dropChance;

    public void Drop()
    {
        if (Random.Range(0, 100) > _dropChance)
            return;
        Vector3 randomAmount = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
        Instantiate(_droppedMaterial, transform.position + randomAmount, Quaternion.identity);
    }
}
