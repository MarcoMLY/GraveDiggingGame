using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Data;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private TransformHolder _player;

    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _mouseOffsetMultiplier = 2f, _smoothness = 0.1f;

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
        Vector3 finalPos = new Vector3(offsetedPosition.x, offsetedPosition.y, 0);
        transform.position = Vector3.Slerp(transform.position, finalPos + _offset, Time.deltaTime / _smoothness);          
    }
}
