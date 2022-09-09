using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScaleObject : MonoBehaviour
{
    //Hand inputs
    [SerializeField] private InputActionReference _Primary;
    [SerializeField] private InputActionReference _Secondary;

    private bool _isGrabbing = false;

    void Awake()
    {
        //Subscribing to the events
        _Primary.action.started += ScaleUp; 
        _Secondary.action.started += ScaleDown;

    }
    
    void OnDestroy()
    {
        //Unsubscribing to the events
        _Primary.action.started -= ScaleUp; 
        _Secondary.action.started -= ScaleDown;

    }

    void OnTriggerEnter(Collider other)
    {
        _isGrabbing = true; 
    }
    
    void OnTriggerExit(Collider other)
    {
        _isGrabbing = false; 
    }
    
    private void ScaleUp(InputAction.CallbackContext obj)
    {
        if (_isGrabbing)
        {
            Debug.Log("Scaling up!");
        }
    }

    private void ScaleDown(InputAction.CallbackContext obj)
    { 
       
        if (_isGrabbing)
        {
            Debug.Log("Scaling Down!");
        }
    }
    
}
