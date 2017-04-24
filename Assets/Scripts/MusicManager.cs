using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour 
{
    //This class will manage all of the music in the game. Just need to add
    //an empty gameobject to hold this script along with 1 audio source

    //variable that holds all of the music in the game
    public AudioClip[] music;

    //variable that we will use to play the music in the game from
    public AudioSource channel;

    //Here is where we grab a reference to the AudioSource
    void Awake()
    {
        channel = GetComponent<AudioSource>();
    }

    //Function that allows us to play the music in the game
    public void PlaySound(AudioClip aClip)
    {
        channel.clip = aClip;
        channel.Play();
    }

    //Function that allows us to set the volume of the music 
    public void SetMusicVolume(float volume)
    {
        channel.volume = volume;
    }

    //Function that allows us to mute/unmute the music in the game
    public void MuteMusic(bool mute)
    {
        channel.mute = mute;
    }
}
