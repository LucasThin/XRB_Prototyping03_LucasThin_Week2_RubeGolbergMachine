using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StoveState
{
    On,
    Off
}
public class TurnStoveOn : MonoBehaviour
{
    [SerializeField] private GameObject _heatMap;
    [SerializeField] private KitchenManager _kitchenManager;

    //public StoveState _stoveState;
    void Start()
    {
        _heatMap.SetActive(false);
        _kitchenManager._stoveState = StoveState.Off;

    }
    
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _heatMap.SetActive(true);
           _kitchenManager._stoveState = StoveState.On;
        }
        else
        {
            _heatMap.SetActive(false);
            _kitchenManager._stoveState = StoveState.Off;
        }
    }
}
