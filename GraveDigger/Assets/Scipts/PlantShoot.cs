using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class PlantShoot : MonoBehaviour
{
    [SerializeField] private float _shootRadius, _waitTime, _lerpTime;
    private float _waitTimer;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _sprite, _shootPos;
    private Transform _currentEnemy;

    private void Awake()
    {
        _waitTimer = _waitTime;
        Vector2 up = transform.up;
        transform.up = Vector2.up;
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

        if (_currentEnemy == null)
            return;
        if (_waitTimer > 0)
        {
            _waitTimer -= Time.deltaTime;
            return;
        }
        Shoot();
    }
    
    private void CheckCloseEnemies()
    {
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
        Instantiate(_bullet, _shootPos.position, _sprite.rotation);
        _waitTimer = _waitTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _shootRadius);
    }
}
