using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlacePlant : MonoBehaviour
{
    [SerializeField] private GameObject _plant;
    [SerializeField] private float _plantRadius;
    [SerializeField] private LayerMask _cannotPlacePlant;
    private CharacterManager _playerManager;
    private InputAction _placePlant;

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

    private void Place(InputAction.CallbackContext context)
    {
        if (!CanPlacePlant())
            return;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 directionToMouse = (mousePos - transform.position).normalized;
        Transform plant = Instantiate(_plant, transform.position, Quaternion.identity).transform;
        plant.up = new Vector3(directionToMouse.x, directionToMouse.y, 0);
    }

    private bool CanPlacePlant()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _plantRadius, _cannotPlacePlant);
        return !hit;
    }
}
