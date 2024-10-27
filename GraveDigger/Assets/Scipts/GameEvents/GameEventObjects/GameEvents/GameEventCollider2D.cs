using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/GameEvents/GameEventCollider2D")]
public class GameEventCollider2D : BasicGameEvent<ListenerCollider2D>
{
    public void EventTriggered(Collider2D info)
    {
        for (int i = 0; i < _listeners.Count; i++)
        {
            _listeners[i].TriggerEvent(info);
        }
    }
}
