using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Data;
using UnityEngine.Events;

public class MakeZombieSounds : MonoBehaviour
{
    [SerializeField] private TransformListHolder _zombies;
    [SerializeField] private AnimationCurve _zombieSoundChance;
    [SerializeField] private int _maxChance;
    [SerializeField] private float _waitTime;
    private float _timer;

    [SerializeField] private UnityEvent _makeZombieSound;

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer > 0)
            return;
        float chance = _zombieSoundChance.Evaluate(_zombies.Variable.Count / _maxChance);
        if (Random.Range(0.00f, 1.00f) < chance)
            _makeZombieSound?.Invoke();
        _timer = _waitTime;
    }
}
