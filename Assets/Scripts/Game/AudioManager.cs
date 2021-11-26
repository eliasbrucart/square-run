using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static public AudioManager instanceAudioManager;
    static public AudioManager Instance { get { return instanceAudioManager; } }

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
        
    }

    void Update()
    {
        
    }
}
