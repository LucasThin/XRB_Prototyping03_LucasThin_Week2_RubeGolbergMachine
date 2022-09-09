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

    [SerializeField] private bool _isGrabbing = false;
    [SerializeField] private bool _isScalingUp = false;
    [SerializeField] private bool _isScalingDown = false;
    private float _scaleSpeed = 2f;
    [SerializeField] private GameObject _grabbedObject;
    private Vector3 temp;

    void Awake()
    {
        //Subscribing to the events
        _Primary.action.started += UpStarted;
        _Primary.action.canceled += UpCancelled;
        _Secondary.action.started += downStarted;
        _Secondary.action.canceled += downCancelled;

    }

    private void downCancelled(InputAction.CallbackContext obj)
    {
        _isScalingDown = false;
    }

    private void downStarted(InputAction.CallbackContext obj)
    {
        _isScalingDown = true;
    }

    private void UpCancelled(InputAction.CallbackContext obj)
    {
        _isScalingUp = false;
    }

    private void UpStarted(InputAction.CallbackContext obj)
    {
        _isScalingUp = true;
    }

    void OnDestroy()
    {
        //Unsubscribing to the events
        _Primary.action.started -= UpStarted;
        _Primary.action.canceled -= UpCancelled;
        _Secondary.action.started += downStarted;
        _Secondary.action.canceled += downCancelled;

    }

    void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Item")) return;
        _grabbedObject = other.gameObject;
        _isGrabbing = true;
    }

    /*
    void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Item")) return;
        _isGrabbing = false;
    }*/

    private void ScaleUp()
    {
        temp = _grabbedObject.transform.localScale;
        temp.x += Time.deltaTime/ _scaleSpeed;
        temp.y += Time.deltaTime/ _scaleSpeed;
        temp.z += Time.deltaTime/ _scaleSpeed;

        _grabbedObject.transform.localScale = temp;
    }

    private void ScaleDown()
    {

        temp = _grabbedObject.transform.localScale;
        temp.x -= Time.deltaTime/ _scaleSpeed;
        temp.y -= Time.deltaTime/ _scaleSpeed;
        temp.z -= Time.deltaTime/ _scaleSpeed;

        _grabbedObject.transform.localScale = temp;
    }

    void Update()
    {
        if (_isGrabbing)
        {
            if (_isScalingUp)
            {
                ScaleUp();
            }
            else if (_isScalingDown)
            {
                ScaleDown();
            }
        }

    }
}
