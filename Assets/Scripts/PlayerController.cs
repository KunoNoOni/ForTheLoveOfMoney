using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour 
{
    float speed = 3f;
    float playerXPos;
    float playerYPos;
    float maxHeight = 5f;
    bool grounded = true;
    float moveVelocity;
    Rigidbody2D player;
    Animator anim;
    LevelManager lm;
    SoundManager sm;

    void Start () 
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    void Update () 
    {
        if(!lm.showingVictoryScreen)
        {
            anim.SetBool("Grounded",grounded);
           
            moveVelocity = speed * Input.GetAxisRaw("Horizontal");
            player.velocity = new Vector2(moveVelocity, player.velocity.y);
            anim.SetFloat("Speed", Mathf.Abs(player.velocity.x));

            if(player.velocity.x > 0)
                transform.localScale = new Vector3(1f,1f,1f);
            else if (player.velocity.x < 0)
                transform.localScale = new Vector3(-1f, 1f, 1f);

            if(grounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1")))
            {
                sm.PlaySound(sm.sounds[2]);
                player.velocity = new Vector2(player.velocity.x,maxHeight);
                grounded = false;
            }
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Platform") || col.gameObject.CompareTag("Cave") && player.velocity.y == 0)
        {
            grounded = true;
        }
    }
}
