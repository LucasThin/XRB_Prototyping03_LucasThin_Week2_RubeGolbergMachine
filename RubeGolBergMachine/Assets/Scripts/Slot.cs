using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject ItemInSlot;
    public Image slotImage;
    private Color originalColor;
    public InputActionReference grabReference = null;
    public GameObject SlotObject;
    
    void Awake()
    {
        grabReference.action.started += OnGrab;
    }

    private void OnGrab(InputAction.CallbackContext obj)
    {
        if(IsItem(SlotObject))
        {
            InsertItem(SlotObject);
        }
    }

    private void InsertItem(GameObject slotObject)
    {
        slotObject.GetComponent<Rigidbody>().isKinematic = true;
        slotObject.transform.SetParent(gameObject.transform, true);
        slotObject.transform.localPosition = Vector3.zero;
        slotObject.transform.localEulerAngles = slotObject.GetComponent<Item>().slotRotation;
        slotObject.GetComponent<Item>().inSlot = true;
        slotObject.GetComponent<Item>().currentSlot = this;
        ItemInSlot = slotObject;
        slotImage.color = Color.gray;
    }

    private bool IsItem(GameObject slotObject)
    {
        //Check if object has item component. Meaning it can be slotted in inventory
        return slotObject.GetComponent<Item>();
    }

    void Start()
    {
        slotImage = GetComponentInChildren<Image>();
        originalColor = slotImage.color;
    }

    void OnTriggerStay(Collider other)
    {
        if (ItemInSlot != null) return;
        SlotObject = other.gameObject;

    }
    // Update is called once per frame
    public void ResetColor()
    {
        slotImage.color = originalColor;
    }
}
