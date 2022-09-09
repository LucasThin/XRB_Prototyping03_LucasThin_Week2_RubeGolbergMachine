using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject _toy;
    [SerializeField] private Transform _spawnPosition;

    [SerializeField] private bool _hasItem = true;
    private int i = 0;
    // Start is called before the first frame update
    void OnTriggerExit(Collider other){
        //_toy.SetActive(false);
        if (other.CompareTag("Item"))
        {
            _hasItem = false;
            // Debug.Log("has Item");
        }
    }
    void OnTriggerEnter(Collider other){
        //_toy.SetActive(false);
        if (other.CompareTag("Item"))
        {
            _hasItem = true;
            // Debug.Log("has Item");
        }
    }

    void Update()
    {
        if (!_hasItem)
        {
            
            if (i == 0)
            {
                Debug.Log("Spawn");
                Instantiate(_toy, _spawnPosition.position, quaternion.identity);
                i++;
            }
            
        }

        if (_hasItem)
        {
            i = 0;
        }
    }
    
    
}