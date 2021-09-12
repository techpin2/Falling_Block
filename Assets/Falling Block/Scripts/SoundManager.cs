using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public Sound[] sounds;

    public static SoundManager soundManager;

    private void Awake()
    {
        if (soundManager == null)
        {
            soundManager = this;
            DontDestroyOnLoad(this.gameObject);
            print("Sound Manager Initialized");
        }
        else
        {
            if (soundManager != this)
            {
                Destroy(this.gameObject);
                print("Sound Manager Already Exist");
            }
            else
            {
                print("Instance Already found");
            }
        }
    }

    public void PlayAudio(SoundType soundType)
    {
        int index = Array.FindIndex(sounds, a => a.soundType == soundType);
        if (index >= 0)
        {
            audioSource.clip = sounds[index].clip;
            audioSource.volume = sounds[index].volume;
            audioSource.Play();
        }
        else
        {
            print("Audio Not Found!!");
        }
    }
}

[System.Serializable]
public class Sound
{
    public SoundType soundType;
    public AudioClip clip;
    [Range(0,1)]
    public float volume;
}

public enum SoundType
{
    NONE,
    GAMEOVER,
    COLLECT
}
