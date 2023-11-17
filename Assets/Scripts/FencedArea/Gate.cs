using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public float rotateSpeed = 1.0f;
    public float openRotation = 90.0f;
    //public float closedRotation = 1.0f; 
    public bool isOpening = false;
    public bool isClosing = false;
    

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
                transform.Rotate(new Vector3(0f, 100f * rotateSpeed, 0f) * Time.deltaTime);
                //transform.localEulerAngles = Vector3.Lerp(currentRotation, new Vector3(currentRotation.x, openRotation, currentRotation.z), rotateSpeed * Time.deltaTime);
            }
            else
            {
                isOpening = false;
            }
        }
        if (isClosing)
        {
            if (currentRotation.y > 1.0f) //set to 1 because if rotation becomes negative, no longer works
            {
                transform.Rotate(new Vector3(0f, -100f * rotateSpeed, 0f) * Time.deltaTime);
                //transform.localEulerAngles = Vector3.Lerp(currentRotation, new Vector3(currentRotation.x, closedRotation, currentRotation.z), rotateSpeed * Time.deltaTime);
            }
            else
            {
                isClosing = false;
            }
        }
    }

    public void OpenGate()
    {
        isOpening = true;
    }

    public void CloseGate()
    {
        isClosing = true;
    }
}
