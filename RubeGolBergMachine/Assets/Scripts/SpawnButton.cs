using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    [SerializeField] private GameObject _toy;
    [SerializeField] private Transform _spawnPosition;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other){
        //_toy.SetActive(false);
        if (!other.CompareTag("Player")) return;
        Instantiate(_toy, _spawnPosition.position, quaternion.identity);
        Debug.Log("Spawn");
    }
}
