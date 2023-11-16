using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject respawnPoint;
    public bool isTimerRunning = false;
    public float respawnDelay = 2.0f;
    public float countdown = 2.0f;

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
            }
        }
    }

    public void Teleport()
    {
        GetComponent<CharacterController>().enabled = false;
        GetComponent<CharacterController>().transform.position = respawnPoint.transform.position;
        GetComponent<CharacterController>().enabled = true;
    }

    public void StartRespawn()
    {
        isTimerRunning = true;
    }
}
