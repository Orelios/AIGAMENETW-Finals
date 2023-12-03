using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCooldown : MonoBehaviour
{
    public bool isTimerRunning = false;
    public float hitCooldown = 1.0f;
    public float countdown = 1.0f;

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
                countdown = hitCooldown;
                if(GetComponent<SheepBT>()  != null)
                {
                    GetComponent<SheepBT>().canBeHit = true;
                }
                //Teleport();
                //GetComponent<Character>().Activate();
                //GetComponent<Character>().ResetHealth();
                //GetComponent<FallDown>().StopFalling();
            }
        }
    }

    public void StartHitCooldown()
    {
        isTimerRunning = true;
    }
}
