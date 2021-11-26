using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    static public AudioManager instanceAudioManager;
    static public AudioManager Instance { get { return instanceAudioManager; } }

    public AudioSource bgMusic;
    public AudioSource sfxSound;

    //private bool state;

    private void Awake()
    {
        if (instanceAudioManager != this && instanceAudioManager != null)
            Destroy(gameObject);
        else
            instanceAudioManager = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        bgMusic.volume = 0.3f;
        sfxSound.volume = 0.5f;
    }

    void Update()
    {
        
    }

    public void EnableMusic()
    {
        bgMusic.mute = !bgMusic.mute;
    }

    public void EnableSFX()
    {
        sfxSound.mute = !sfxSound.mute;
    }
}
