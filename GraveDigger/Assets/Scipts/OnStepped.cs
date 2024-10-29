using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnStepped : MonoBehaviour
{
    [SerializeField] private LayerMask _stepLayer;
    [SerializeField] private UnityEvent _hasBeenStepped;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_stepLayer.Contains(collision.gameObject.layer))
            _hasBeenStepped?.Invoke();
    }
}
