using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    //public GameObject playerPrefab;
    //public Vector3 p1SpawnPos;

    public GameObject playerPrefab;
    public Vector3 spawnPos;

    private void Start()
    {
        spawnPos = new Vector3(-36.08f, 2.84f, -19.75f); // Player 1 spawn position
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPos, Quaternion.identity);
    }
}
