using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAssets : MonoBehaviour
{
    private static SoundAssets _i;
    public static SoundAssets i
    {
        get
        {
            if (_i == null) _i = (Instantiate(Resources.Load("SoundAssets")) as GameObject).GetComponent<SoundAssets>();
            return _i;
        }
    }

    public SFXAudioClip[] sfxAudioClipArray;
    public MusicAudioClip[] musicAudioClipArray;

    [System.Serializable]
    public class SFXAudioClip
    {
        public SoundManager.SFX sfx;
        public AudioClip audioClip;
        public float volume;
    }

    [System.Serializable]
    public class MusicAudioClip
    {
        public SoundManager.Music music;
        public AudioClip audioClip;
        public float volume;
    }

}
