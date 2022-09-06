using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum PanState
{
    Cold,
    Hot
}

public class FryingPan : MonoBehaviour
{
    public StoveState _stoveState;

    [SerializeField] private KitchenManager _kitchenManager;
    // Start is called before the first frame update
    void Start()
    {
        _stoveState = _kitchenManager._stoveState;
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.GetComponent<StoveTop>()) return;
        
        if (_kitchenManager._stoveState == StoveState.On)
        {
            _kitchenManager._panState = PanState.Hot;
        }
        
    }

    void Update()
    {
        if (_kitchenManager._panState == PanState.Hot)
        {
            Debug.Log("Pan is ready!");
        }
    }
}
