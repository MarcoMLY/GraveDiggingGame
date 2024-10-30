using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YSort : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;

    // Start is called before the first frame update
    void Update()
    {
        _renderer.sortingOrder = -(int)(transform.position.y * 100);
    }
}
