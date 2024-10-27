using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform _attackPos;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _attackLayer;
    [SerializeField] private int _damage;
    [SerializeField] private float _waitTime;
    [SerializeField] private float _distanceToPlayer;
    private CharacterManager _playerManager;
    private InputAction _attack;
    private float _waitTimer;

    private void Awake()
    {
        _playerManager = GetComponent<CharacterManager>();
        _attackPos.position = transform.position + (Vector3.up * _distanceToPlayer);
        InputActionMap playerMap = _playerManager.InputAsset.FindActionMap("Player");

        _attack = playerMap.FindAction("Attack");
    }

    private void OnEnable()
    {
        _attack.performed += Attack;
    }

    private void OnDisable()
    {
        _attack.performed -= Attack;
    }

    private void Update()
    {
        if (_waitTimer > 0)
        {
            _waitTimer -= Time.deltaTime;
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _attackPos.position = transform.position + ((mousePos - transform.position) * _distanceToPlayer);
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
        Gizmos.DrawWireSphere(transform.position + (Vector3.up * _distanceToPlayer), _radius);
    }
}
