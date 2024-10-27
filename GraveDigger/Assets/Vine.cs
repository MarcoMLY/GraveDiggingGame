using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Vine : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;

    [SerializeField] private float _speed = 3f, _duration = 10f, _moveDuration = 5f, _damage = 1f;
    [SerializeField] Vector2 _hitbox;
    [SerializeField] LayerMask _passThrough;
    [SerializeField] private UnityEvent _onSpawn, _onDestroy;
    //private TimerManager _timer;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(DestroyTimer());
        _onSpawn?.Invoke();
        _lineRenderer.SetPosition(0, transform.position);
    }

    private IEnumerator StopMovingTimer()
    {
        yield return new WaitForSeconds(_moveDuration);
        StopMoving();
    }

    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(_duration);
        DestroyProjectile();
    }

    private void RenderVine()
    {
        _lineRenderer.SetPosition(1, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        MoveFoward();

        RaycastHit2D[] hit = Physics2D.CircleCastAll(_lineRenderer.GetPosition(0), _hitbox.x, transform.up, Vector2.Distance(_lineRenderer.GetPosition(0), _lineRenderer.GetPosition(1)));

        foreach (RaycastHit2D obsticle in hit)
        {
            IDameagable damageable = obsticle.collider.gameObject.GetComponent<IDameagable>();
            if (damageable != null && _damage > 0)
            {
                damageable.Damage(_damage, gameObject, false);
            }

            if (!_passThrough.Contains(obsticle.collider.gameObject.layer))
            {
                DestroyProjectile();
            }
        }
    }

    private void MoveFoward()
    {
        Vector3 fowardDirection = transform.up * _speed * Time.deltaTime;
        transform.position += fowardDirection;
        RenderVine();
    }

    private void StopMoving()
    {

    }

    private void DestroyProjectile()
    {
        _onDestroy?.Invoke();
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _hitbox);
    }
}
