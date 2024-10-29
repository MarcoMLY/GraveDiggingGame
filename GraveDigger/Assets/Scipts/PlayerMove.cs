using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour, IStateable
{
    public bool Enabled { get; set; }

    [SerializeField] private float _moveSpeed;

    private CharacterManager _playerManager;
    private PlayerAnimation _playerAnimation;
    private SetVelocity _setVelocity;

    private InputAction _move;

    private Vector2 _moveDirection;

    [SerializeField] private AudioSource _footsteps;
    private bool _playerStopped = true;

    // Start is called before the first frame update
    void Awake()
    {
        _playerManager = GetComponent<CharacterManager>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _setVelocity = GetComponent<SetVelocity>();

        InputActionMap playerMap = _playerManager.InputAsset.FindActionMap("Player");
        playerMap.Enable();

        _move = playerMap.FindAction("Move");
    }

    private void OnEnable()
    {
        _move.performed += Move;
    }

    private void OnDisable()
    {
        _move.performed -= Move;
    }

    private void Update()
    {
        //if (!Enabled)
        //    return;
        if (_move.WasReleasedThisFrame())
            _moveDirection = Vector2.zero;

        bool turnTo = _moveDirection != Vector2.zero;
        _setVelocity.ChangeVelocity(_moveDirection, turnTo);

        float moveMagnitude = _setVelocity.GetRBVelocity().magnitude;
        if (moveMagnitude == 0)
            Footsteps(false);
        if (moveMagnitude > 0)
            Footsteps(true);
    }

    // Update is called once per frame
    void Move(InputAction.CallbackContext context)
    {
        Vector2 moveAmount = context.ReadValue<Vector2>();
        _moveDirection = moveAmount * _moveSpeed;
    }

    private void Footsteps(bool turnOnOrOff)
    {
        if (turnOnOrOff && _playerStopped)
        {
            _footsteps.Play();
            _playerStopped = false;
        }
        if (!turnOnOrOff && !_playerStopped)
        {
            _footsteps.Stop();
            _playerStopped = true;
        }
    }

    public State HandleState()
    {
        return State.Continue;
    }

    public void OnStateEnabled()
    {
        _moveDirection = _move.ReadValue<Vector2>() * _moveSpeed;
    }
}
