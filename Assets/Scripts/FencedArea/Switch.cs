using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Gate gatePivotLeft;
    public Gate gatePivotRight;

    private bool isPlayed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(gatePivotLeft.GetIsClosed()) //only checks gateLeft status
            {
                if (isPlayed == false)
                {
                    SoundManager.PlaySFXOneShot(SoundManager.SFX.SwitchOpen);
                    SoundManager.PlaySFXOneShot(SoundManager.SFX.FenceOpen);
                    isPlayed = true;
                }
                gatePivotLeft.OpenGate();
                gatePivotRight.OpenGate();
            }
            if (gatePivotLeft.GetIsOpen())
            {
                if (isPlayed == true)
                {
                    SoundManager.PlaySFXOneShot(SoundManager.SFX.SwitchClose);
                    SoundManager.PlaySFXOneShot(SoundManager.SFX.FenceClose);
                    isPlayed = false;
                }
                gatePivotLeft.CloseGate();
                gatePivotRight.CloseGate();
            }
        }
    }
}
