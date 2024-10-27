using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Profiling;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _fadeTime;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void StartDeathScreen(string deathText)
    {
        Debug.Log("!");
        _text.text = deathText;
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float timer = 0;
        while (timer < _fadeTime)
        {
            timer += Time.deltaTime;
            _canvasGroup.alpha = timer / _fadeTime;
            yield return null;
        }
        _canvasGroup.alpha = 1;
    }
}
