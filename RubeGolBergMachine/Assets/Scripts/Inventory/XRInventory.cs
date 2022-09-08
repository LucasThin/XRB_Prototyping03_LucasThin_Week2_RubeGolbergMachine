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
    }
    

    void Start()
    {
        Inventory.SetActive(false);
        UIActive = false;
    }
    
    void Update()
    {
        if (UIActive)
        {
            Inventory.transform.position = Anchor.transform.position;
            Inventory.transform.eulerAngles =
                new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);
        }
    }
}
