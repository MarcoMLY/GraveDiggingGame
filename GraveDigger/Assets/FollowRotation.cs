using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class FollowRotation : MonoBehaviour
{
    [SerializeField] private Transform _rotationFollow;
    [SerializeField] private float _lerpSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.up = Vector3.Slerp(transform.up, _rotationFollow.up, Time.deltaTime * _lerpSpeed);
    }
}
