﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {
    Player player;

    public bool isJustStart = false;
    public bool isJump = false;

    public float jumpPower = 9;

    // Use this for initialization
    void Start () {
        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player.getState() == PlayerState.Dead)
            return;
        //if moving then  get input. basically if not dashing currently.
        if (player.getState() == PlayerState.Moving)
        {
            //Basically start of statemachine with bools.
            if (Input.GetButtonDown("Jump"))
                isJustStart = true;

        }
    }

    void FixedUpdate()
    {
        if (player.getState() == PlayerState.Dead)
            return;

        if (player.getState() == PlayerState.Moving)
        {
            //makes sure you dont press jump twice.
            if (isJustStart == true && isJump == false)
            {
                isJustStart = false;
                jump();
            }
        }
    }

    //starts to jump, sets the animation accordingly and adds force to the character.
    void jump()
    {
        isJump = true;
        player.anim.SetBool("Jumping", true);
        //player.rb.velocity += new Vector2(0,5f);
        player.rb.AddForce(Vector2.up * jumpPower * 10,ForceMode2D.Impulse);
    }

    //checks of hits walkable objects and sets jump to false and changes the animation.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJump = false;
        player.anim.SetBool("Jumping", false);

        if (collision.gameObject.tag == "Walkable")
        {
            isJump = false;
            player.anim.SetBool("Jumping", false);
        }
    }
}

