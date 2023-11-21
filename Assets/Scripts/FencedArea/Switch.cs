using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Gate gatePivotLeft;
    public Gate gatePivotRight;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(gatePivotLeft.GetIsClosed()) //only checks gateLeft status
            {
                gatePivotLeft.OpenGate();
                gatePivotRight.OpenGate();
            }
            if (gatePivotLeft.GetIsOpen())
            {
                gatePivotLeft.CloseGate();
                gatePivotRight.CloseGate();
            }
        }
    }
}
