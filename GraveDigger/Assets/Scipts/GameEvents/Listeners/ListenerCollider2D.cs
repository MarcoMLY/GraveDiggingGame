using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ListenerCollider2D : MonoBehaviour
{
    [SerializeField] private UnityEventCollider2D _event;
    [SerializeField] private GameEventCollider2D _gameEvent;

    private void OnEnable()
    {
        _gameEvent.AddListener(this);
    }

    private void OnDisable()
    {
        _gameEvent.RemoveListener(this);
    }

    public void TriggerEvent(Collider2D info)
    {
        _event?.Invoke(info);
    }
}
