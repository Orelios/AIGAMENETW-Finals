using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Teleport()
    {
        GetComponent<CharacterController>().enabled = false;
        GetComponent<CharacterController>().transform.position = respawnPoint.transform.position;
        GetComponent<CharacterController>().enabled = true;
    }
}
