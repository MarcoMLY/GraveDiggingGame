using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Data;

public class AddToTransformList : MonoBehaviour
{
    [SerializeField] private TransformListHolder _transformList;

    // Start is called before the first frame update
    void OnEnable()
    {
        _transformList.ClearData();
        _transformList.AddData(transform);
    }

    private void OnDisable()
    {
        _transformList.RemoveData(transform);
    }
}
