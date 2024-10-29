using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Data;

public class SpriteBasedOnHealth : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private float[] _percentages;
    [SerializeField] private Health _health;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        float healthValue = (_health.CurrentHealth / _health.TotalHealth) * 100;
        for (int i = 0; i < _percentages.Length; i++)
        {
            if (healthValue <= _percentages[i])
            {
                _spriteRenderer.sprite = _sprites[i];
            }
        }
    }
}
