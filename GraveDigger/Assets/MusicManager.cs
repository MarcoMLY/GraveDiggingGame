using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Data;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private FloatHolder _crystalMaxHealth, _crystalCurrentHealth;
    [SerializeField] private AudioSource _melody, drums, guituar;
    [SerializeField] private int _drumHealthPercent, _guitarHealthPercent;
    private float _loopTime = 9.6f, _timer;

    // Start is called before the first frame update
    void Awake()
    {
        _timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer < _loopTime)
            return;
        float crystalHealthPercent = (_crystalCurrentHealth.Variable / _crystalMaxHealth.Variable) * 100;
        if (crystalHealthPercent <= _drumHealthPercent)
            drums.volume = 1;
        if (crystalHealthPercent <= _guitarHealthPercent)
            guituar.volume = 1;

        if (drums.time != _melody.time)
            drums.time = _melody.time;
        if (guituar.time != _melody.time)
            guituar.time = _melody.time;
    }
}
