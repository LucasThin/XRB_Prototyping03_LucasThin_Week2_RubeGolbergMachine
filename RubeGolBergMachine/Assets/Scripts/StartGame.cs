using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _ballObject;

    void Awake()
    {
        _ballObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        _ballObject.SetActive(true);
    }
}
