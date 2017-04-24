using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Options : MonoBehaviour 
{
    public Slider musicSlider;
    public Slider soundSlider;

    MusicManager mm;
    SoundManager sm;

	void Start () 
	{
        mm = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        musicSlider.value = mm.channel.volume;
        soundSlider.value = sm.channels[0].volume;
	}

    public void SetMusicVolume()
    {
        mm.SetMusicVolume(musicSlider.value);
        Registry.musicLevel = musicSlider.value;
    }

    public void SetSoundVolume()
    {
        sm.SetSoundVolume(soundSlider.value);
        Registry.soundLevel = soundSlider.value;
    }
}
