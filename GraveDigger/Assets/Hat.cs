using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hat : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private int _hatHealth;
    [SerializeField] private UnityEvent _onHatDestroy;

    // Update is called once per frame
    void Update()
    {
        if (_health.TotalHealth - _health.CurrentHealth >= _hatHealth)
        {
            _onHatDestroy?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
