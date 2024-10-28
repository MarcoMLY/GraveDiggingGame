using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Data;

public class ProtectionPointHit : MonoBehaviour
{
    [SerializeField] private Transform[] _effects;
    [SerializeField] private SpriteRenderer[] _spriteRenderers;
    [SerializeField] private Gradient _gradient;
    private float[] _timers;

    [SerializeField] private float _animationTime, _endSize;

    [SerializeField] private FloatHolder _maxCrystalHealth;
    [SerializeField] private FloatHolder _currentCrystalHealth;

    // Start is called before the first frame update
    void Awake()
    {
        _timers = new float[_effects.Length];
    }

    // Update is called once per frame
    void Update()
    {
        float currentStrength = 1 - ((_currentCrystalHealth.Variable / _maxCrystalHealth.Variable));
        for (int i = 0; i < _timers.Length; i++)
        {
            if (_timers[i] <= 0)
            {
                _timers[i] = 0;
                _effects[i].localScale = new Vector2(0, 0);
                continue;
            }

            _timers[i] -= Time.deltaTime;
            float currentScale = (1 - (_timers[i] / _animationTime)) * _endSize;
            Color color = _gradient.Evaluate(1 - _timers[i] / _animationTime);
            _spriteRenderers[i].color = new Color(color.r, color.g, color.b, color.a * currentStrength);
            _effects[i].localScale = new Vector2(currentScale, currentScale);
        }
    }

    public void OnProtectionPointHit()
    {
        for (int i = 0; i < _timers.Length; i++)
        {
            if (_timers[i] == 0)
            {
                _timers[i] = _animationTime;
                return;
            }
        }
        _timers[0] = _animationTime;
    }
}
