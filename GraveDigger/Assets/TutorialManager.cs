using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Data;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private IntHolder _wave, _food;
    [SerializeField] private TransformListHolder _zombies;

    [SerializeField] private CanvasGroup[] _tutorials;
    [SerializeField] private float _fadeTime, _waitTime;
    private bool _foodTutorialStarted = false, _foodTutorialEnded = false;

    private void Awake()
    {
        Tutorial(0);
    }

    private void Update()
    {
        if (_food.Variable >= 2 && !_foodTutorialStarted)
        {
            Tutorial(2);
            _foodTutorialStarted = true;
        }
    }

    public void SpacePressed()
    {
        if (!_foodTutorialEnded && _foodTutorialStarted)
        {
            FinishTutorial(2);
            _foodTutorialEnded = true;
        }
    }

    public void Tutorial(int index)
    {
        StartCoroutine(StartTutorial(index));
    }

    public void FinishTutorial(int index)
    {
        StartCoroutine(EndTutorial(index));
    }

    private IEnumerator StartTutorial(int index)
    {
        yield return new WaitForSeconds(_waitTime);
        float timer = 0;
        while (timer < 1)
        {
            timer += Time.deltaTime / _fadeTime;
            _tutorials[index].alpha = timer;
            yield return null;
        }
        _tutorials[index].alpha = 1;
    }

    private IEnumerator EndTutorial(int index)
    {
        float timer = 1;
        while (timer > 0)
        {
            timer -= Time.deltaTime / _fadeTime;
            _tutorials[index].alpha = timer;
            yield return null;
        }
        _tutorials[index].alpha = 0;
    }
}
