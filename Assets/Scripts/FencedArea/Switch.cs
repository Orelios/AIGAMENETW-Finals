using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Gate gate;
    
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
            if(gate.GetIsClosed())
            {
                gate.OpenGate();
            }
            if (gate.GetIsOpen())
            {
                gate.CloseGate();
            }
        }
    }
}
