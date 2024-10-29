using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Data;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private BoolHolder _paused;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        _canvasGroup.alpha = _paused.Variable ? 1 : 0;
    }

    public void RestartGame()
    {
        if (_paused.Variable)
        {
            Time.timeScale = 1;
            _paused.ChangeData(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
