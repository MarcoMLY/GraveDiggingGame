using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Data;
using UnityEngine.UI;

public class PickPlants : MonoBehaviour
{
    [SerializeField] private PlantType[] _plantTypes;
    [SerializeField] private IntHolder _plantTypeIndex;
    [SerializeField] private Image _plantImage, _highlight;
    [SerializeField] private TextMeshProUGUI _foodAmount;
    [SerializeField] private Vector3 _higlightOffset;
    private List<Transform> _plantTransforms = new List<Transform>();

    [SerializeField] private Animator _plantTypeAdded;
    [SerializeField] private TextMeshProUGUI _plantTypeAddedText;

    [SerializeField] private float _distances;
    private int _currentIndex = 0;

    // Start is called before the first frame update
    void Awake()
    {
        _plantImage.sprite = _plantTypes[0].Sprite;
        _plantTransforms.Add(_plantImage.transform);
        _highlight.transform.position = _plantTransforms[0].position + _higlightOffset;
        _foodAmount.text = _plantTypes[0].FoodNeeded.ToString();
        _plantTypeIndex.ChangeData(0);
    }

    public void AddNextPlantType()
    {
        Transform newPlant = Instantiate(_plantImage.gameObject, _plantImage.transform.position + new Vector3(_distances * _plantTransforms.Count, 0, 0), Quaternion.identity, transform).transform;
        newPlant.GetComponent<Image>().sprite = _plantTypes[_plantTypes.Length - 1].Sprite;
        newPlant.GetChild(0).GetComponent<TextMeshProUGUI>().text = _plantTypes[_plantTypes.Length - 1].FoodNeeded.ToString();
        _plantTransforms.Add(newPlant);
        _plantTypeAddedText.text = "you got the " + _plantTypes[_plantTypes.Length - 1].name + " plant!";
        _plantTypeAdded.SetTrigger("NewPlant");
    }

    public void SwitchPlantType(int direction)
    {
        _currentIndex += direction;
        if (_currentIndex < 0)
            _currentIndex = 0;
        if (_currentIndex > _plantTransforms.Count - 1)
            _currentIndex = _plantTransforms.Count - 1;
        _highlight.transform.position = _plantTransforms[_currentIndex].position + _higlightOffset;
        _plantTypeIndex.ChangeData(_currentIndex);
    }
}
