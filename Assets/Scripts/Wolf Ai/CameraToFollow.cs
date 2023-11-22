using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToFollow : MonoBehaviour
{

    public Camera cameraToFollow;
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cameraToFollow.transform.position);
    }
}
