using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour 
{
    public bool playerDead = false;
    public int numberOfGoldBagsLeft;
    public GameObject victoryScreen;
    public Text text;
    public bool showingVictoryScreen = false;
    public GameObject options;

    bool nextLevel = false;
    float cooldown = 3f;
    float cooldownNextLevel = 3f;
    MusicManager mm;
    SoundManager sm;

    void Start () 
	{
        numberOfGoldBagsLeft = 5;
        text.text = "LIVES: " + Registry.playerLives;
        Debug.Log("currentScene is " + Registry.currentScene + " playerLives is " + Registry.playerLives + " and levelNum is "+Registry.levelNum);
        mm = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        mm.SetMusicVolume(Registry.musicLevel);
        sm.SetSoundVolume(Registry.soundLevel);
        mm.PlaySound(mm.music[0]);
	}
		
	void Update () 
	{
        if(Input.GetKeyDown(KeyCode.O))
        {
            if(options.activeSelf)
                options.SetActive(false);
            else
                options.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if(playerDead)
        {
            cooldown -= Time.deltaTime;
            if(cooldown <= 0)
            {
                Registry.playerLives -= 1;
                text.text = "LIVES: " + Registry.playerLives;
                if(Registry.playerLives == 0)
                {
                    SceneManager.LoadScene(8); //this is for the losescreen
                }
                else
                {
                    SceneManager.LoadScene(Registry.currentScene);    
                }
            }
        }

        if(numberOfGoldBagsLeft == 0)
            ShowVictoryScreen();
        
        if(nextLevel)
        {
            cooldownNextLevel -= Time.deltaTime;
            if(cooldownNextLevel <= 0)
            {
                Debug.Log("currentScene is "+ Registry.currentScene);
                if(Registry.levelNum < 6)
                    SceneManager.LoadScene(Registry.currentScene);
                else
                    SceneManager.LoadScene(7); //this is for the winscreen
            }
        }
    }

    void ShowVictoryScreen()
    {
        if(!showingVictoryScreen)
        {
            showingVictoryScreen = true;
            victoryScreen.SetActive(true);   
            Registry.currentScene += 1;
            Registry.levelNum += 1;
            nextLevel = true;   
        }
    }
}
