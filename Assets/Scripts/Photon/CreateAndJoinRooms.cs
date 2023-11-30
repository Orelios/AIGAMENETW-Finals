using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public GameObject createInput;
    public GameObject joinInput;

    public void CreateRoom()
    {
        string roomName = createInput.GetComponent<TMP_InputField>().text;
        if (roomName.Length > 1)
        {
            PhotonNetwork.CreateRoom(roomName);
            Debug.Log("Created: " + roomName);
        }
        else
        {
            Debug.Log("Create fail: " + roomName);
        }
    }

    public void JoinRoom()
    {
        string roomName = joinInput.GetComponent<TMP_InputField>().text;
        if(roomName.Length > 1)
        {
            PhotonNetwork.JoinRoom(roomName);
            Debug.Log("Joined: " + roomName);
        }
        else
        {
            Debug.Log("join fail: " + roomName);
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("01_Lobby");
    }
}
