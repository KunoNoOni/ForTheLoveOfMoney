﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Instructions : MonoBehaviour 
{	
	void Update () 
	{
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(2);
        }	

        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
	}
}
