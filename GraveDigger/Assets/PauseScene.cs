using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScene : MonoBehaviour
{
    private float _timer;

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
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
    }
}
