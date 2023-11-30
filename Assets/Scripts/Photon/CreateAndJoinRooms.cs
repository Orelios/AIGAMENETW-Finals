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
        PhotonNetwork.CreateRoom(roomName);
    }

    public void JoinRoom()
    {
        string roomName = createInput.GetComponent<TMP_InputField>().text;
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("01_Lobby");
    }
}
