using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class KillPlayer : MonoBehaviour 
{
    public GameObject deathEffect;
    LevelManager lm;
    SoundManager sm;

    void Start()
    {
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            sm.PlaySound(sm.sounds[1]);
            col.gameObject.SetActive(false);
            Instantiate(deathEffect,col.transform.position,col.transform.rotation);
            lm.playerDead = true;
        }
    }
}
