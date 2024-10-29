using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrassyPatches : MonoBehaviour
{
    [SerializeField] private GameObject _grassyPatch;
    [SerializeField] private int _minAmount, _maxAmount;
    [SerializeField] private float _minSize, _maxSize;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;

    private void Awake()
    {
        PlaceGrassyPatches();
    }

    private void PlaceGrassyPatches()
    {
        int amount = Random.Range(_minAmount, _maxAmount);
        for (int i = 0; i < amount; i++)
        {
            Vector3 position = new Vector3(Random.Range(_minX, _maxX), Random.Range(_minY, _maxY), 0);
            Transform patch = Instantiate(_grassyPatch, position, Quaternion.identity, transform).transform;
            float size = Random.Range(_minSize, _maxSize);
            patch.localScale = new Vector2(size, size);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(_minX, _minY), new Vector2(_minX, _maxY));
        Gizmos.DrawLine(new Vector2(_minX, _maxY), new Vector2(_maxX, _maxY));
        Gizmos.DrawLine(new Vector2(_maxX, _maxY), new Vector2(_maxX, _minY));
        Gizmos.DrawLine(new Vector2(_maxX, _minY), new Vector2(_minX, _minY));
    }
}
