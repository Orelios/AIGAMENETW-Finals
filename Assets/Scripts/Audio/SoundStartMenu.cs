using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStartMenu : MonoBehaviour
{
    void Awake()
    {
        SoundManager.PlayMusic(SoundManager.Music.MenuTheme);
    }
}
