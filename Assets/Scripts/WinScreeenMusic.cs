using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class WinScreeenMusic : MonoBehaviour 
{
    MusicManager mm;

    void Start () 
	{
        mm = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        mm.SetMusicVolume(Registry.musicLevel);
        mm.PlaySound(mm.music[1]);
	}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
