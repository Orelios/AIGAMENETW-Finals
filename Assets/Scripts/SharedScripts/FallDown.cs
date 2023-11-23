using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour
{
    public bool isFalling = false;
    public float fallSpeed = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = GetComponent<CharacterController>().transform.position;
        if (isFalling == true)
        {
            GetComponent<CharacterController>().transform.position = new Vector3(currentPos.x, currentPos.y - fallSpeed, currentPos.z);
        }
    }

    public void StartFalling()
    {
        GetComponent<CharacterController>().enabled = false;
        isFalling = true;
    }

    public void StopFalling()
    {
        isFalling = false;
        GetComponent<CharacterController>().enabled = true;
    }
}
