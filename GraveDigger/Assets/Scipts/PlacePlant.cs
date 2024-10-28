using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Data;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlacePlant : MonoBehaviour
{
    [SerializeField] private GameObject[] _plants;
    [SerializeField] private PlantType[] _plantTypes;
    [SerializeField] private float _plantRadius;
    [SerializeField] private LayerMask _cannotPlacePlant;
    [SerializeField] private IntHolder _plantFood, _plantIndex;
    private CharacterManager _playerManager;
    private InputAction _placePlant;

    [SerializeField] private UnityEvent _cantPlacePlant;
    [SerializeField] private UnityEvent _notEnoughPlantFood;

    private void Awake()
    {
        _playerManager = GetComponent<CharacterManager>();
        InputActionMap playerMap = _playerManager.InputAsset.FindActionMap("Player");
        _placePlant = playerMap.FindAction("PlacePlant");
    }

    private void OnEnable()
    {
        _placePlant.performed += Place;
    }

    private void OnDisable()
    {
        _placePlant.performed -= Place;
    }
    
    private bool EnoughPlantFood()
    {
        return _plantFood.Variable >= _plantTypes[_plantIndex.Variable].FoodNeeded;
    }

    private void Place(InputAction.CallbackContext context)
    {
        if (!EnoughPlantFood())
        {
            _notEnoughPlantFood?.Invoke();
            return;
        }
        if (!CanPlacePlant())
        {
            _cantPlacePlant?.Invoke();
            return;
        }
        _plantFood.AddAmount(-_plantTypes[_plantIndex.Variable].FoodNeeded);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 directionToMouse = (mousePos - transform.position).normalized;
        Transform plant = Instantiate(_plants[_plantIndex.Variable], transform.position, Quaternion.identity).transform;
        plant.up = new Vector3(directionToMouse.x, directionToMouse.y, 0);
    }

    private bool CanPlacePlant()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _plantRadius, _cannotPlacePlant);
        return !hit;
    }
}
