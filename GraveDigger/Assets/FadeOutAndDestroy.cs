using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutAndDestroy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private float _fadeOutTime;
    private float _fadeOutTimer;

    // Start is called before the first frame update
    void OnEnable()
    {
        _fadeOutTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _fadeOutTimer += Time.deltaTime;
        if (_fadeOutTimer < _fadeOutTime)
        {
            _spriteRenderer.color = _gradient.Evaluate(_fadeOutTimer / _fadeOutTime);
            return;
        }
        Destroy(gameObject);
    }
}
