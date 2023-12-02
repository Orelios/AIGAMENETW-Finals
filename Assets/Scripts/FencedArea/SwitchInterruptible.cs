using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInterruptible : MonoBehaviour
{
    public GateInterruptible gatePivotLeft;
    public GateInterruptible gatePivotRight;
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
        if(isPlayed == false)
        {
            SoundManager.PlaySFXOneShot(SoundManager.SFX.SwitchOpen);
            SoundManager.PlaySFXOneShot(SoundManager.SFX.FenceOpen);
            isPlayed = true;
        }
        if (other.CompareTag("Player"))
        {
            gatePivotLeft.isOpening = true;
            gatePivotRight.isOpening = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isPlayed == true)
        {
            SoundManager.PlaySFXOneShot(SoundManager.SFX.SwitchClose);
            SoundManager.PlaySFXOneShot(SoundManager.SFX.FenceClose);
            isPlayed = false;
        }
        if (other.CompareTag("Player"))
        {
            gatePivotLeft.isOpening = false;
            gatePivotRight.isOpening = false;
        }
    }

}

