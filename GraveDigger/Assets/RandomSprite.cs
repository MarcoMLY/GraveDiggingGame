using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _spriteRenderers;
    [SerializeField] private Sprite[] _sprites;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private bool _randomizeYFlip = false;

    // Start is called before the first frame update
    void Awake()
    {
        bool flipY = Random.Range(0, 2) == 0;
        bool flip = Random.Range(0, 2) == 0;
        Sprite sprite = _sprites[Random.Range(0, _sprites.Length)];
        for (int i = 0; i < _spriteRenderers.Length; i++)
        {
            _spriteRenderers[i].flipY = _randomizeYFlip ? flipY : false;
            _spriteRenderers[i].flipX = flip;
            _spriteRenderers[i].sprite = sprite;
        }
    }
}
