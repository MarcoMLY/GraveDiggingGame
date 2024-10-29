using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Data;
using UnityEngine.UI;

public class UINumber : MonoBehaviour
{
    private TextMeshProUGUI _text;
    [SerializeField] private IntHolder _intHolder;
    [SerializeField] private string _addOn;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _intHolder.ChangeData(0);
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = _intHolder.Variable.ToString() + _addOn;
    }
}
