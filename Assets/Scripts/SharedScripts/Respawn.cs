using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    //public float spawnX = 0, spawnY = 5, spawnZ = 0;
    public bool isTimerRunning = false;
    public float respawnDelay = 5.0f;
    public float countdown = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning == true)
        {
            if (countdown > 0)
            {
                countdown -= Time.deltaTime;
            }
            else
            {
                isTimerRunning = false;
                countdown = respawnDelay;
                Teleport();
                GetComponent<Character>().Activate();
                GetComponent<Character>().ResetHealth();
                GetComponent<FallDown>().StopFalling();
            }
        }
    }

    public void Teleport()
    {
        GetComponent<CharacterController>().enabled = false;
        GetComponent<CharacterController>().transform.position = new Vector3(0, 5, 0);
        GetComponent<CharacterController>().enabled = true;
    }

    public void StartRespawn()
    {
        isTimerRunning = true;
    }
}
