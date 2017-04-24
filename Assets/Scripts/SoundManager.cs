using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour 
{
    //This class will allow you to have 8 sounds all playing at the same time
    //You will need a empty game object to place the script on and also to
    //hold the 8 AudioSources needed by the script.

    //variable to hold all of the sounds in the game
    public AudioClip[] sounds;

    //variable for the 8 AudioSources
    public AudioSource[] channels;

    //Here is where we grab a reference to the AudioSource
    void Awake()
    {
        channels = GetComponents<AudioSource>();
    }

    //Function that allows us to play any one of the sounds in the sounds
    //array
    public void PlaySound(AudioClip aClip)
    {
        foreach(AudioSource channel in channels)
        {
            if(!channel.isPlaying)
            {
                channel.clip = aClip;
                channel.Play();
                return;
            }
        }
    }

    //Function that allows us to set the volume of all of the sound channels
    public void SetSoundVolume(float volume)
    {
        foreach(AudioSource channel in channels)
        {
            channel.volume = volume;
        }
    }

    //Function that allows us to mute/unmute all of the sounds channels
    public void MuteSounds(bool mute)
    {
        foreach(AudioSource channel in channels)
        {
            channel.mute = mute;  
        }
    }
}
