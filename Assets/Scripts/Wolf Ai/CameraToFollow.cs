using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToFollow : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.Euler(80, 0, 0);
    }
}
