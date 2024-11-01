using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hat : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private int _hatHealth;
    [SerializeField] private UnityEvent _onHatDestroy;
    [SerializeField] private UnityEventTransform _onHatDestroyTransform;

    public void CheckOnHatDestroyTransforn(Transform attacker)
    {
        if (!gameObject.activeInHierarchy)
            return;
        if (_health.TotalHealth - _health.CurrentHealth >= _hatHealth)
        {
            _onHatDestroy?.Invoke();
            _onHatDestroyTransform?.Invoke(attacker);
            gameObject.SetActive(false);
        }
    }
}
