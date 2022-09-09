using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dominoes : MonoBehaviour
{
   //Hand inputs
    [SerializeField] private InputActionReference _Primary;
    [SerializeField] private InputActionReference _Secondary;
    
    [SerializeField] private GameObject _Object;
    private Vector3 temp;
    private Quaternion tempRot;


    void Awake()
    {
        //Subscribing to the events
        _Primary.action.performed += Increase;
        _Secondary.action.performed += Decrease;

    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Dominoes")) return;
        _Object = other.gameObject;
    }

    private void Decrease(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    private void Increase(InputAction.CallbackContext obj)
    {
        int i = 1;
        if (i < 7)
        {
            temp = _Object.transform.position;
            tempRot = _Object.transform.rotation;
            temp.z -= 0.15f;
            Instantiate(_Object, temp, tempRot);
            
        }
    }
}
