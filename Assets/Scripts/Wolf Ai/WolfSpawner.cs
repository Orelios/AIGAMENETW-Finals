using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class WolfSpawner : MonoBehaviourPunCallbacks
{
    public GameObject wolf;
    [SerializeField]
    private string wolfId; //What is the id of the prefab we want to spawn from the pool
    [SerializeField]
    private float maxSpawnTimer;
    private float spawnTimer;
    private bool isSpawning;
    [SerializeField]
    private Vector3 spawnPosition;

    void Start()
    {
        //SetTimer();
    }

    void Update()
    {
        //Don't do anything if you are not the master client
            if (!PhotonNetwork.IsMasterClient) return;

        if (!isSpawning)
            StartCoroutine(SpawnCoroutine());

        /*
        if (spawnTimer <= 0)
        {
            SpawnWolves();
            SetTimer();
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }*/
    }

    IEnumerator SpawnCoroutine()
    {
        //Generate a random waiting interval
        //spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        isSpawning = true;
        //Wait for the spawnInterval
        yield return new WaitForSeconds(maxSpawnTimer);
        //SpawnWolf();
        SpawnOverNetwork();
        isSpawning = false;
    }

    private void SpawnOverNetwork()
    {
        SoundManager.PlaySFXOneShot(SoundManager.SFX.WolfGrowl);
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.InstantiateRoomObject(wolfId, GetSpawnPosition(), Quaternion.identity);
        }
    }
    private void SpawnWolf()
    {
        //Get an object from the pool
        GameObject enemy = ObjectPoolManager.Instance.GetPooledObject(wolfId);
        //Did we get an object from the pool?
        if (enemy != null)
        {
            //Position the enemy
            enemy.transform.position = GetSpawnPosition();
            enemy.SetActive(true);
        }
    }

    private Vector3 GetSpawnPosition()
    {
        return spawnPosition;
    }
    // FORMER FUNCTIONS
    //private void SetTimer()
    //{
    //    spawnTimer = maxSpawnTimer;
    //}
    //private void SpawnWolves()
    //{
    //    ObjectPoolManager.SpawnObject(wolf, transform.position, transform.rotation, ObjectPoolManager.PoolType.Enemies);
    //}
}
