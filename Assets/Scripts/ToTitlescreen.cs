using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class ToTitlescreen : MonoBehaviour 
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            Registry.playerLives = 5;
            Registry.currentScene = 2;
            Registry.levelNum = 1;
            SceneManager.LoadScene(0);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
