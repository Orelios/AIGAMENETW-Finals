using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour
{
    public bool isFalling = false;
    public float fallSpeed = 1.0f;

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
            currentPos += new Vector3(0, -fallSpeed, 0);
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
