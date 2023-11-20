using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum SFX
    {

    }

    public enum Music
    {

    }

    private static GameObject sfxGameObject, sfxOneShotGameObject, musicGameObject;
    public static AudioSource sfxAudioSource, sfxOneShotAudioSource, musicAudioSource;

    private static Dictionary<SFX, float> sfxTimerDictionary;
    public static void Initialize()
    {
        sfxTimerDictionary = new Dictionary<SFX, float>();
    }

    private static bool CanPlaySFX(SFX sfx)
    {
        switch (sfx)
        {
            default:
                return true;
        }
    }

    public static void PlaySFX(SFX sfx)
    {
        if (sfxGameObject == null)
        {
            sfxGameObject = new GameObject("SFX");
            sfxAudioSource = sfxGameObject.AddComponent<AudioSource>();
        }
        sfxAudioSource.clip = GetSFXClip(sfx);
        sfxAudioSource.Play();
    }

    public static void PlayOneShotSound(SFX sfx)
    {
        if (sfxOneShotGameObject == null)
        {
            sfxOneShotGameObject = new GameObject("One Shot SFX");
            sfxOneShotAudioSource = sfxOneShotGameObject.AddComponent<AudioSource>();
        }
        sfxOneShotAudioSource.PlayOneShot(GetSFXClip(sfx));
    }

    public static void StopSFX()
    {
        if (sfxGameObject == null)
        {
            return;
        }
        sfxAudioSource.Stop();
    }

    public static void PlayMusic(Music music)
    {
        if (musicGameObject == null)
        {
            musicGameObject = new GameObject("Music");
            musicAudioSource = musicGameObject.AddComponent<AudioSource>();
        }
        musicAudioSource.clip = GetMusicAudioClip(music);
        musicAudioSource.loop = true;
        musicAudioSource.Play();
    }

    public static void StopMusic()
    {
        if (musicGameObject == null)
        {
            return;
        }
        musicAudioSource.Stop();
    }

    private static AudioClip GetSFXClip(SFX sfx)
    {
        foreach (SoundAssets.SFXAudioClip sfxAudioClip in SoundAssets.i.sfxAudioClipArray)
        {
            if (sfxAudioClip.sfx == sfx)
            {
                return sfxAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + sfx + "not found!");

        return null;
    }

    private static AudioClip GetMusicAudioClip(Music music)
    {
        foreach (SoundAssets.MusicAudioClip musicAudioClip in SoundAssets.i.musicAudioClipArray)
        {
            if (musicAudioClip.music == music)
            {
                return musicAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + music + "not found!");

        return null;
    }

    private static float GetSFXClipVolume(SFX sfx)
    {
        foreach (SoundAssets.SFXAudioClip sfxAudioClip in SoundAssets.i.sfxAudioClipArray)
        {
            if (sfxAudioClip.sfx == sfx)
            {
                return sfxAudioClip.volume;
            }
        }
        Debug.LogError("Sound " + sfx + "not found!");
        float defaultVolume = 1.0f;
        return defaultVolume;
    }

    private static float GetMusicClipVolume(Music music)
    {
        foreach (SoundAssets.MusicAudioClip musicAudioClip in SoundAssets.i.musicAudioClipArray)
        {
            if (musicAudioClip.music == music)
            {
                return musicAudioClip.volume;
            }
        }
        Debug.LogError("Sound " + music + "not found!");
        float defaultVolume = 1.0f;
        return defaultVolume;
    }
}
