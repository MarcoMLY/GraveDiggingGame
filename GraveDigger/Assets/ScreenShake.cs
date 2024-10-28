using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void BigScreenShake()
    {
        _animator.Play("BigScreenShake");
    }

    public void MediumScreenShake()
    {
        _animator.Play("MediumScreenShake");
    }

    public void SmallScreenShake()
    {
        _animator.Play("SmallScreenShake");
    }
}
