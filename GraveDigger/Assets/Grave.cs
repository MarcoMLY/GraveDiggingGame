using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    [SerializeField] private LayerMask _protectionPointLayer;

    // Start is called before the first frame update
    void Awake()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 2f, _protectionPointLayer);
        if (hit)
        {
            transform.position = new Vector3(transform.position.x + 10f, transform.position.y - 5f, 0);
        }
    }
}
