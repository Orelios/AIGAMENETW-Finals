using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public float rotateSpeed = 1.0f;
    public float openRotation = 270.0f;
    public float closedRotation = 180.0f;
    public bool clockwise = true;
    public bool isOpening = false;
    public bool isClosing = false;
    private bool isOpen = false;
    private bool isClosed = false;
    

    // Start is called before the first frame update
    void Start()
    {
        isClosed = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRotation = transform.localEulerAngles;
        if (clockwise == true)
        {
            if (isOpening == true && isClosing == false)
            {
                if (currentRotation.y < openRotation)
                {
                    transform.Rotate(new Vector3(0f, 100f * rotateSpeed, 0f) * Time.deltaTime);
                    //transform.localEulerAngles = Vector3.Lerp(currentRotation, new Vector3(currentRotation.x, openRotation, currentRotation.z), rotateSpeed * Time.deltaTime);
                }
                else
                {
                    isOpening = false;
                    isOpen = true;
                    isClosed = false;
                }
            }
            if (isClosing == true && isOpening == false)
            {
                if (currentRotation.y > closedRotation)
                {
                    transform.Rotate(new Vector3(0f, -100f * rotateSpeed, 0f) * Time.deltaTime);
                    //transform.localEulerAngles = Vector3.Lerp(currentRotation, new Vector3(currentRotation.x, closedRotation, currentRotation.z), rotateSpeed * Time.deltaTime);
                }
                else
                {
                    isClosing = false;
                    isClosed = true;
                    isOpen = false;
                }
            }
        }
        else
        {
            if (isOpening == true && isClosing == false)
            {
                if (currentRotation.y > openRotation)
                {
                    transform.Rotate(new Vector3(0f, -100f * rotateSpeed, 0f) * Time.deltaTime);
                    //transform.localEulerAngles = Vector3.Lerp(currentRotation, new Vector3(currentRotation.x, openRotation, currentRotation.z), rotateSpeed * Time.deltaTime);
                }
                else
                {
                    isOpening = false;
                    isOpen = true;
                    isClosed = false;
                }
            }
            if (isClosing == true && isOpening == false)
            {
                if (currentRotation.y < closedRotation)
                {
                    transform.Rotate(new Vector3(0f, 100f * rotateSpeed, 0f) * Time.deltaTime);
                    //transform.localEulerAngles = Vector3.Lerp(currentRotation, new Vector3(currentRotation.x, closedRotation, currentRotation.z), rotateSpeed * Time.deltaTime);
                }
                else
                {
                    isClosing = false;
                    isClosed = true;
                    isOpen = false;
                }
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

    public bool GetIsOpen()
    {
        return isOpen;
    }

    public bool GetIsClosed()
    {
        return isClosed;
    }
}
