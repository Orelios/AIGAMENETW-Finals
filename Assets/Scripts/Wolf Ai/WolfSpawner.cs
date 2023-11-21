using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSpawner : MonoBehaviour
{
    public GameObject wolf;
    public float maxSpawnTimer;
    private float spawnTimer;
    void Start()
    {
        SetTimer(); 
    }

    void Update()
    {
        if(spawnTimer <= 0)
        {
            SpawnWolves();
            SetTimer();
        }
        else
        {
            spawnTimer -= Time.deltaTime; 
        }
    }
    private void SetTimer()
    {
        spawnTimer = maxSpawnTimer; 
    }
    private void SpawnWolves()
    {
        ObjectPoolManager.SpawnObject(wolf, transform.position, transform.rotation, ObjectPoolManager.PoolType.Enemies);
    }
}
