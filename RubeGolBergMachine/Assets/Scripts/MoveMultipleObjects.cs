using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveMultipleObjects : MonoBehaviour
{
    [SerializeField] private InputActionReference _leftgrabReference;
    [SerializeField] private InputActionReference _rightgrabReference;
    private bool _isGrabbing = false;

    void Awake()
    {
        _leftgrabReference.action.started += isGrabbing;
        _leftgrabReference.action.canceled += isNotGrabbing;
        
        _rightgrabReference.action.started += isGrabbing;
        _rightgrabReference.action.canceled += isNotGrabbing;
    }

    private void isNotGrabbing(InputAction.CallbackContext obj)
    {
        _isGrabbing = false;
    }

    private void isGrabbing(InputAction.CallbackContext obj)
    {
        _isGrabbing = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        if (_isGrabbing)
        {
            transform.parent = other.gameObject.transform;
        }
        else
        {
            transform.parent = null;
        }
    }
}
