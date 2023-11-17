using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateInterruptible : MonoBehaviour
{
    public float rotateSpeed = 1.0f;
    public float openRotation = 90.0f;
    public float closedRotation = 0.0f; 
    public bool isOpening = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRotation = transform.localEulerAngles;
        if (isOpening)
        {
            if (currentRotation.y < openRotation)
            {
                transform.localEulerAngles = Vector3.Lerp(currentRotation, new Vector3(currentRotation.x, openRotation, currentRotation.z), rotateSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (currentRotation.y > closedRotation)
            {
                transform.localEulerAngles = Vector3.Lerp(currentRotation, new Vector3(currentRotation.x, closedRotation, currentRotation.z), rotateSpeed * Time.deltaTime);
            }
        }
    }
}
