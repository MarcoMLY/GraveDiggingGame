using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] private Transform _attackPos;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _attackLayer;
    [SerializeField] private int _damage;
    [SerializeField] private float _waitTime;
    private float _waitTimer;

    private void Update()
    {
        if (_waitTimer > 0)
        {
            _waitTimer -= Time.deltaTime;
            return;
        }
        Attack();
    }

    public void Attack()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(_attackPos.position, _radius, _attackLayer);
        foreach (Collider2D hit in collider)
        {
            IDameagable damageable = hit.GetComponent<IDameagable>();
            if (damageable != null)
            {
                _waitTimer = _waitTime;
                damageable.Damage(_damage, gameObject, false);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPos.position, _radius);
    }
}
