using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Data;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private TransformHolder _player;

    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _mouseOffsetMultiplier = 2f, _smoothness = 0.1f;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_player.Variable == null)
            return;
        Move();
    }

    private void Move()
    {
        Vector2 playerPos = _player.Variable.position;

        Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 directionToMouse = (mousePos - playerPos).normalized;
        Vector2 offsetedPosition = playerPos + (directionToMouse * _mouseOffsetMultiplier);
        float finalX = Mathf.Clamp(offsetedPosition.x + _offset.x, _minX, _maxX);
        float finalY = Mathf.Clamp(offsetedPosition.y + _offset.y, _minY, _maxY);
        Vector3 finalPos = new Vector3(finalX, finalY, _offset.z);
        transform.position = Vector3.Slerp(transform.position, finalPos, Time.deltaTime / _smoothness);          
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
