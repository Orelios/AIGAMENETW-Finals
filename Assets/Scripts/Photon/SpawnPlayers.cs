using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    //public GameObject playerPrefab;
    //public Vector3 p1SpawnPos;
    //public static SpawnPlayers instance;
    //public Transform[] spawnPoints;
    public GameObject playerPrefab;
    public Vector3 spawnPos;

    private void Start()
    {
        //instance = this;
        spawnPos = new Vector3(0f, 3f, 0f); // Player 1 spawn position
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPos, Quaternion.identity);
    }
}
