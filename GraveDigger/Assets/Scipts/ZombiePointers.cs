using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Data;

public class ZombiePointers : MonoBehaviour
{
    [SerializeField] private TransformListHolder _zombies;
    [SerializeField] private Transform[] _pointers;
    [SerializeField] private Vector2 _minBounds;
    [SerializeField] private Vector2 _maxBounds;
    [SerializeField] private TransformHolder _camera;

    private void Update()
    {
        SetPointers();
    }

    private void SetPointers()
    {
        for (int i = 0; i < _pointers.Length; i++)
        {
            if (i >= _zombies.Variable.Count)
            {
                _pointers[i].gameObject.SetActive(false);
                continue;
            }
            Vector2 zombiePosition = _zombies.Variable[i].position;
            float XMin = _minBounds.x + _camera.Variable.position.x;
            float XMax = _maxBounds.x + _camera.Variable.position.x;
            float YMin = _minBounds.y + _camera.Variable.position.y;
            float YMax = _maxBounds.y + _camera.Variable.position.y;
            if (zombiePosition.x > XMin && zombiePosition.x < XMax && zombiePosition.y > YMin && zombiePosition.y < YMax)
            {
                _pointers[i].gameObject.SetActive(false);
                continue;
            }
            _pointers[i].gameObject.SetActive(true);
            Vector2 direction = _zombies.Variable[i].position - _camera.Variable.position;
            float finalPosX = Mathf.Clamp(zombiePosition.x, XMin, XMax);
            float finalPosY = Mathf.Clamp(zombiePosition.y, YMin, YMax);
            _pointers[i].position = new Vector3(finalPosX, finalPosY, 0);
            _pointers[i].up = direction.normalized;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(_minBounds.x, _minBounds.y), new Vector2(_minBounds.x, _maxBounds.y));
        Gizmos.DrawLine(new Vector2(_minBounds.x, _maxBounds.y), new Vector2(_maxBounds.x, _maxBounds.y));
        Gizmos.DrawLine(new Vector2(_maxBounds.x, _maxBounds.y), new Vector2(_maxBounds.x, _minBounds.y));
        Gizmos.DrawLine(new Vector2(_maxBounds.x, _minBounds.y), new Vector2(_minBounds.x, _minBounds.y));
    }
}
