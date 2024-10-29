using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Data;

public class SoundEffectManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private float _pitchChangeAmount, _volumeChange;
    [SerializeField] private AudioSource[] _audioSources;
    [SerializeField] private float[] _volumes;
    private int _currentAudioSource;
    private float _normalPitch = 1;
    [SerializeField] private float _normalVolume;

    [SerializeField] private BoolHolder _paused;

    public void PlayeSound(string spaces)
    {
        if (_paused.Variable)
            return;
        AudioSource _source = _audioSources[_currentAudioSource];
        string[] twoParts = spaces.Split(' ');
        int from = int.Parse(twoParts[0]);
        int to = from;
        if (twoParts.Length > 1)
            to = int.Parse(twoParts[1]);
        AudioClip clip = _audioClips[from];
        int clipIndex = Random.Range(from, to + 1);
        clip = _audioClips[clipIndex];

        _source.volume = _volumes[clipIndex] + Random.Range(-_volumeChange / 2, _volumeChange);
        _source.pitch = _normalPitch + Random.Range(-_pitchChangeAmount / 2, _pitchChangeAmount);
        _source.PlayOneShot(clip);

        _currentAudioSource += 1;
        if (_currentAudioSource >= _audioSources.Length)
            _currentAudioSource = 0;
    }
}
