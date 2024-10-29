using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Data;

public class PauseScene : MonoBehaviour
{
    private float _timer;
    private bool _paused;

    [SerializeField] private BoolHolder _pausedHolder;

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.unscaledDeltaTime;
            if (_timer <= 0)
                Time.timeScale = 1;
        }
    }

    public void PauseForSplitSecond(float time)
    {
        Time.timeScale = 0;
        _timer = time;
    }

    public void Pause()
    {
        if (!_paused)
        {
            Time.timeScale = 0;
            _paused = true;
            _pausedHolder.ChangeData(_paused);
            return;
        }
        Time.timeScale = 1;
        _paused = false;
        _pausedHolder.ChangeData(_paused);
    }
}
