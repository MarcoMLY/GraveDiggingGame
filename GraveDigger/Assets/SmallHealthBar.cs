using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Transform _fill;
    [SerializeField] private Gradient _colorGradient;
    [SerializeField] private SpriteRenderer _sliderImage;
    [SerializeField] private SpriteRenderer _backroundImage;
    private bool _disabled = true;

    private void Awake()
    {
        DisableSlider();
    }

    private void Update()
    {
        float value = _health.CurrentHealth / _health.TotalHealth;
        if (value < 1 && _disabled)
            EnableSlider();
        _fill.transform.localScale = new Vector2(value, 1);
        _sliderImage.color = _colorGradient.Evaluate(value);
    }

    private void DisableSlider()
    {
        _sliderImage.enabled = false;
        _backroundImage.enabled = false;
    }

    private void EnableSlider()
    {
        _disabled = false;
        _sliderImage.enabled = true;
        _backroundImage.enabled = true;
    }
}
