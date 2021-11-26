using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMReference : MonoBehaviour
{
    private AudioManager AMInstance;
    void Start()
    {
        AMInstance = FindObjectOfType<AudioManager>();
    }

    public void ChangeStateMusic()
    {
        if(AMInstance != null)
            AMInstance.EnableMusic();
    }

    public void ChangeStateSFX()
    {
        if (AMInstance != null)
            AMInstance.EnableSFX();
    }
}
