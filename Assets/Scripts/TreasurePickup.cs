using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class TreasurePickup : MonoBehaviour 
{
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
            sm.PlaySound(sm.sounds[0]);
            Destroy(this.gameObject);
            lm.numberOfGoldBagsLeft -= 1;
        }
    }
}
