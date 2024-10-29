using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplat : MonoBehaviour
{
    [SerializeField] private float _timeBetweenFrames;
    [SerializeField] private Sprite[] _bloodSplatEnd;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _randomSizeChangeAmount;

    private void OnEnable()
    {
        transform.localScale = new Vector2(transform.localScale.x + Random.Range(-_randomSizeChangeAmount, _randomSizeChangeAmount), transform.localScale.y + Random.Range(-_randomSizeChangeAmount, _randomSizeChangeAmount));
        _spriteRenderer.flipY = Random.Range(0, 2) == 0;
        StartCoroutine(NextFrame());
    }

    private IEnumerator NextFrame()
    {
        yield return new WaitForSeconds(_timeBetweenFrames);
        _spriteRenderer.sprite = _bloodSplatEnd[Random.Range(0, _bloodSplatEnd.Length)];
    }
}
