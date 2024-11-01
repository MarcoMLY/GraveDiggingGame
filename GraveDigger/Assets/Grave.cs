using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class Grave : MonoBehaviour
{
    [SerializeField] private LayerMask _protectionPointLayer;
    private bool _checkedIfCorrectPlace = false;

    private void OnEnable()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 8f, _protectionPointLayer);
        while (hit)
        {
            float x = Random.Range(-20, 20);
            float y = Random.Range(-20, 20);
            transform.position = new Vector3(x, y, 0);
            hit = Physics2D.OverlapCircle(transform.position, 8f, _protectionPointLayer);
        }
    }

    private void Update()
    {
        if (!_checkedIfCorrectPlace)
        {
            Collider2D hit = Physics2D.OverlapCircle(transform.position, 8f, _protectionPointLayer);
            while (hit)
            {
                float x = Random.Range(-20, 20);
                float y = Random.Range(-20, 20);
                transform.position = new Vector3(x, y, 0);
                hit = Physics2D.OverlapCircle(transform.position, 8f, _protectionPointLayer);
            }
            _checkedIfCorrectPlace = true;
        }
    }
}
