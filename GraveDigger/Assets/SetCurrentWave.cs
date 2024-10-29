using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Data;
using UnityEngine.Events;

public class SetCurrentWave : MonoBehaviour
{
    [SerializeField] private WaveManagerScript _waveManager;
    [SerializeField] private IntHolder _intHolder;
    [SerializeField] private int _currentWave;

    [SerializeField] private int[] _addNewPlant;
    private bool[] _plantRecieved;
    [SerializeField] private UnityEvent _onNewPlant;

    private void Awake()
    {
        _plantRecieved = new bool[_addNewPlant.Length];
    }
    // Update is called once per frame
    void Update()
    {
        _intHolder.ChangeData(_currentWave);
        for (int i = 0; i < _addNewPlant.Length; i++)
        {
            if (_currentWave == _addNewPlant[i] && !_plantRecieved[i])
            {
                _onNewPlant?.Invoke();
                _plantRecieved[i] = true;
            }
        }
    }
}
