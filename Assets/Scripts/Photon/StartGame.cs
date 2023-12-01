using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using TMPro;

public class StartGame : MonoBehaviourPunCallbacks
{
    /*
    private void GetCurrentRoomPlayers()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }
        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
        {
            return;
        }
        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListings(playerInfo.Value);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom()
    {
        int index = _listings.FindIndex(x => x.Player == otherPlayer);
        if (index != 1)
        {
            Destroy(_listings[index].gameObject);
            _listings.RemoveAt(index);
        }
    }*/

    public void OnClickStartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("02_Game");
        }
    }
}
