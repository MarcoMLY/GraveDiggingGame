using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToMouse : MonoBehaviour
{
    [SerializeField] private float _lerpSpeed;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 directionToMouse = mousePos - transform.position;
        transform.up = Vector3.Slerp(transform.up, new Vector3(directionToMouse.x, directionToMouse.y, 0), Time.deltaTime * _lerpSpeed);
    }
}
