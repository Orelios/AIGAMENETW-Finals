using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateInterruptible : MonoBehaviourPun
{
    public float rotateSpeed = 1.0f;
    public float openRotation = 90.0f;
    public float closedRotation = 0.0f;
    public bool clockwise = true;
    public bool isOpening = false;

    private const byte ROTATE_PIVOT_EVENT = 0;

    // Start is called before the first frame update
    void Start()
    {
        
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
            //float g = (float)datas[1];
            //float b = (float)datas[2];
            //_spriteRenderer.color = new Color(r, g, b, 1f);
            //isOpening = isOpening;
        }
    }

    private void RotatePivot()
    {
        Vector3 currentRotation = transform.localEulerAngles;
        if (clockwise == true)
        {
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
        else
        {
            if (isOpening)
            {
                if (currentRotation.y > openRotation)
                {
                    transform.localEulerAngles = Vector3.Lerp(currentRotation, new Vector3(currentRotation.x, openRotation, currentRotation.z), rotateSpeed * Time.deltaTime);
                }
            }
            else
            {
                if (currentRotation.y < closedRotation)
                {
                    transform.localEulerAngles = Vector3.Lerp(currentRotation, new Vector3(currentRotation.x, closedRotation, currentRotation.z), rotateSpeed * Time.deltaTime);
                }
            }
        }
        object[] datas = new object[] { isOpening };
        PhotonNetwork.RaiseEvent(ROTATE_PIVOT_EVENT, datas, RaiseEventOptions.Default, SendOptions.SendReliable);
    }
}
