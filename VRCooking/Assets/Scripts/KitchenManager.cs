using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KitchenManager : MonoBehaviour
{
    public StoveState _stoveState;

    public PanState _panState;
    // Start is called before the first frame update
    void Start()
    {
        _stoveState = StoveState.Off;
        _panState = PanState.Cold;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
