using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Connect();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        //PhotonNetwork.OnRoomListUpdate();
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Connect()
    {
        // Check first if we are already connected to the Photon Network
        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("Already connected to photon network.");
        }
        else
        {
            Debug.Log("Not yet connected to photon network. Trying to connect..");
            PhotonNetwork.ConnectUsingSettings();
        }
    }
}
