using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.HID;

public class PlantShoot : MonoBehaviour
{
    [SerializeField] private float _shootRadius, _waitTime, _lerpTime;
    private float _waitTimer;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _sprite, _shootPos;
    private Transform _currentEnemy;

    [SerializeField] private int _amountOfShots, _angle;

    [SerializeField] private UnityEvent _plantShot;

    private void Awake()
    {
        _waitTimer = _waitTime;
        Vector3 up = transform.up;
        transform.up = Vector3.up;
        _sprite.up = up;
    }

    // Update is called once per frame
    void Update()
    {
        CheckCloseEnemies();
        if (_currentEnemy != null)
        {
            Vector2 toEnemyDirection = _currentEnemy.position - transform.position;
            _sprite.up = Vector2.Lerp(_sprite.up, toEnemyDirection, _lerpTime * Time.deltaTime);
        }
        if (_waitTimer > 0)
        {
            _waitTimer -= Time.deltaTime;
            return;
        }

        if (_currentEnemy == null)
            return;
        Shoot();
    }
    
    private void CheckCloseEnemies()
    {
        if (transform.up != Vector3.up)
        {
            Vector2 up = transform.up;
            transform.up = Vector2.up;
            _sprite.up = up;
        }
        float shortestDistance = Mathf.Infinity;
        Transform enemyTransform = null;
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, _shootRadius, _enemyLayer);
        foreach (Collider2D enemy in hit)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance <= shortestDistance)
            {
                shortestDistance = distance;
                enemyTransform = enemy.transform;
            }
            if (enemy.transform == _currentEnemy)
            {
                enemyTransform = enemy.transform;
                break;
            }
        }
        _currentEnemy = enemyTransform;
    }

    private void Shoot()
    {
        _plantShot?.Invoke();

        float shootAngle = _sprite.eulerAngles.z - (_angle / 2);
        for (int i = 0; i < _amountOfShots; i++)
        {
            Instantiate(_bullet, _shootPos.position, Quaternion.Euler(0, 0, shootAngle + ((_angle / _amountOfShots) * i)));
        }

        
        _waitTimer = _waitTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _shootRadius);
    }
}
