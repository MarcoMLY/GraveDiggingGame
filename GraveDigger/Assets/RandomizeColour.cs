using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeColour : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SpriteRenderer _spriteRnederer;
    [SerializeField] private Gradient _gradient;

    // Start is called before the first frame update
    void Start()
    {
        if (_camera != null)
            _camera.backgroundColor = _gradient.Evaluate(Random.Range(0.00f, 1.00f));
        if (_spriteRnederer != null)
            _spriteRnederer.color = _gradient.Evaluate(Random.Range(0.00f, 1.00f));
    }
}
