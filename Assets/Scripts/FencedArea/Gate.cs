using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviourPun
{
    public float rotateSpeed = 1.0f;
    public float openRotation = 270.0f;
    public float closedRotation = 180.0f;
    public bool clockwise = true;
    public bool isOpening = false;
    public bool isClosing = false;
    private bool isOpen = false;
    private bool isClosed = false;

    private const byte ROTATE_PIVOT_EVENT = 1;

    // Start is called before the first frame update
    void Start()
    {
        isClosed = true;
    }

    // Update is called once per frame
    void Update()
    {
        RotatePivot();
    }

    private void OnEnable() //listen to when an event is dispatched by Photon
    {
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived; //if you want events to always fire on the object whether it's enabled or not, move this code to on Awake() then remove upon destroyed
    }

    private void OnDisable() //events won't fire on this object while it's disabled
    {
        PhotonNetwork.NetworkingClient.EventReceived -= NetworkingClient_EventReceived; //remove listener
    }

    private void NetworkingClient_EventReceived(EventData obj)
    {
        if (obj.Code == ROTATE_PIVOT_EVENT) //method called whenever we receive an event
        {
            object[] datas = (object[])obj.CustomData;
            bool isOpening = (bool)datas[0];
            bool isOpen = (bool)datas[1];
            bool isClosing = (bool)datas[2];
            bool isClosed = (bool)datas[3];
        }
    }

    private void RotatePivot()
    {
        Vector3 currentRotation = transform.localEulerAngles;
        if (clockwise == true)
        {
            if (isOpening == true && isClosing == false)
            {
                if (currentRotation.y < openRotation)
                {
                    transform.Rotate(new Vector3(0f, 100f * rotateSpeed, 0f) * Time.deltaTime);
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
                }
                else
                {
                    isClosing = false;
                    isClosed = true;
                    isOpen = false;
                }
            }
        }
        object[] datas = new object[] { isOpening, isClosing, isOpen, isClosed };
        PhotonNetwork.RaiseEvent(ROTATE_PIVOT_EVENT, datas, RaiseEventOptions.Default, SendOptions.SendReliable);
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
