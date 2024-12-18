using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Data;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class DroppedMaterial : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private float _colliderRadius;
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private IntHolder _plantFoodHolder;

    [SerializeField] private GameEventString _sendControlPrompt;
    [SerializeField] private GameEventString _endControlPrompt;
    [SerializeField] private string _controlPrompt;
    [SerializeField] private int _importance, _pickUpAmount = 1;
    private bool _controlPromptSent, _pickingThingsUp = false;

    [SerializeField] private UnityEvent _onPickedUp;

    private void Update()
    {
        if (!CanBeSuckedUp())
        {
            if (_controlPromptSent)
                _endControlPrompt.EventTriggered(_controlPrompt + "|" + _importance.ToString());
            _controlPromptSent = false;
            return;
        }

        if (!_controlPromptSent)
        {
            _sendControlPrompt.EventTriggered(_controlPrompt + "|" + _importance.ToString());
            _controlPromptSent = true;
        }

        if (_pickingThingsUp)
        {
            _endControlPrompt.EventTriggered(_controlPrompt + "|" + _importance.ToString());
            GetPickedUp();
        }
    }

    private bool CanBeSuckedUp()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _colliderRadius, _layerMask);
        return hit;
    }
    
    private void GetPickedUp()
    {
        _plantFoodHolder.AddAmount(_pickUpAmount);
        _onPickedUp?.Invoke();
        Destroy(gameObject);
    }

    public void PickingThingsUp()
    {
        _pickingThingsUp = true;
    }

    public void StoppedPickingUp()
    {
        _pickingThingsUp = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _colliderRadius);
    }
}
