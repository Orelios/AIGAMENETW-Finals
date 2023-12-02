using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudioController : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SoundManager.PlaySFXOneShot(SoundManager.SFX.SwitchClose);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SoundManager.PlaySFXOneShot(SoundManager.SFX.SwitchOpen);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SoundManager.PlaySFXOneShot(SoundManager.SFX.WalkMud);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SoundManager.PlaySFXOneShot(SoundManager.SFX.WolfDeath);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SoundManager.PlaySFXOneShot(SoundManager.SFX.WolfGrowl);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SoundManager.PlaySFXOneShot(SoundManager.SFX.WolfHurt);
        }
    }
}
