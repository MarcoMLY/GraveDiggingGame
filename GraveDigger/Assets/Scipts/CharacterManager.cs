using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Data;
using UnityEngine.InputSystem;

public class CharacterManager : MonoBehaviour
{
    public InputActionAsset InputAsset;

    [SerializeField] private Rigidbody2D _rb;
    public Rigidbody2D Rb { get => _rb; }

    public Transform PlayerSprite;
}
