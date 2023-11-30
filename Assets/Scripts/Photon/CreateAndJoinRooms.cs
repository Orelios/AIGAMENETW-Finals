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
        PhotonNetwork.CreateRoom(createInput.GetComponent<TMP_InputField>().text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.GetComponent<TMP_InputField>().text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("01_Lobby");
    }
}
