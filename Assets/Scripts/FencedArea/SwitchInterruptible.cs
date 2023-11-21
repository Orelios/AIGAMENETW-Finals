using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInterruptible : MonoBehaviour
{
    public GateInterruptible gatePivotLeft;
    public GateInterruptible gatePivotRight;

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
            gatePivotLeft.isOpening = true;
            gatePivotRight.isOpening = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gatePivotLeft.isOpening = false;
            gatePivotRight.isOpening = false;
        }
    }

}

