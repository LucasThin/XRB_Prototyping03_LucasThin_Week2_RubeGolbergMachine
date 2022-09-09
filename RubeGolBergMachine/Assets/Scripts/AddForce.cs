using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public float Force = 2f;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        //if (!other.gameObject.CompareTag("Item")) return;
        other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * Force, ForceMode.Impulse);
    
    }
}
