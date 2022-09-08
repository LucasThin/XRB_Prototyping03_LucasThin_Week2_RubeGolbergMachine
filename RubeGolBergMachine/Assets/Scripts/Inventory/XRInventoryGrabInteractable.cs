using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRInventoryGrabInteractable : XRGrabInteractable
{
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        base.OnSelectEntering(args);

        if (gameObject.GetComponent<Item>() == null) return;
        if (gameObject.GetComponent<Item>().inSlot)
        {
            gameObject.GetComponentInParent<Slot>().ItemInSlot = null;
            gameObject.transform.parent = null;
            gameObject.GetComponent<Item>().inSlot = false;
            gameObject.GetComponent<Item>().currentSlot.ResetColor();
            gameObject.GetComponent<Item>().currentSlot = null;
        }
    }
}
