using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Registry : MonoBehaviour 
{
    public static int currentScene = 2;
    public static int playerLives = 5;
    public static int levelNum = 1;
    public static float musicLevel = .1f;
    public static float soundLevel = .1f;

	void Awake()
	{
        DontDestroyOnLoad(this.gameObject);	
	}

}
