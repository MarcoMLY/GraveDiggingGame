using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.Events
{
    [System.Serializable]
    public class UnityEventBool : UnityEvent<bool> { }

    [System.Serializable]
    public class UnityEventInt : UnityEvent<int> { }

    [System.Serializable]
    public class UnityEventFloat : UnityEvent<float> { }

    [System.Serializable]
    public class UnityEventString : UnityEvent<string> { }

    [System.Serializable]
    public class UnityEventSound : UnityEvent<AudioClip> { }

    [System.Serializable]
    public class UnityEventCollider2D : UnityEvent<Collider2D> { }

    [System.Serializable]
    public class UnityEventTransform : UnityEvent<Transform> { }
}

