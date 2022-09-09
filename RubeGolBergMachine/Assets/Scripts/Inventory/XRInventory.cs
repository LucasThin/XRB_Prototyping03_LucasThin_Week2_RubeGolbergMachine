using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

//Script purpose: attaching a gameobject to a certain anchor and having the ability to enable and disable it.
public class XRInventory : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject Anchor;
    private bool UIActive;
    public InputActionReference buttonReference = null;

    void Awake()
    {
        buttonReference.action.started += OpenInventory;
    }
    
    private void OpenInventory(InputAction.CallbackContext obj)
    {
        UIActive = !UIActive;
        Inventory.SetActive(UIActive);
        Inventory.gameObject.transform.position = Anchor.transform.position;
        Inventory.gameObject.transform.rotation = Anchor.transform.rotation;
    }
    

    void Start()
    {
        Inventory.SetActive(false);
        UIActive = false;
    }
    
}
