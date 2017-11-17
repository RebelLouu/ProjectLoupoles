﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    PlayerState playerState;

    PlayerLife playerLife;
    PlayerRun playerRun;
    PlayerDash playerDash;
    PlayerJump playerJump;
    [HideInInspector]
    public PlayerShoot playerShoot;

    public Transform bulletParent;

    [HideInInspector]
    public Rigidbody2D rb;
    public Animator anim;

    public RaycastHit2D hit;

    public float hor; // Horizontal axis for the inputs.
    public float savedGravityScale = 25f; //get gravity scale normally by rb if want to change it in the inspector

    bool isFacingRight;

    void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerLife = GetComponent<PlayerLife>();
        playerRun = GetComponent<PlayerRun>();
        playerDash = GetComponent<PlayerDash>();
        playerJump = GetComponent<PlayerJump>();
        playerShoot = GetComponent<PlayerShoot>();
        isFacingRight = true;
        savedGravityScale = rb.gravityScale;
    }

    private void Update()
    {
        hor = Input.GetAxisRaw("Horizontal");
        flipPlayer();
    }
    void FixedUpdate () {
        hit = Physics2D.Raycast(transform.position, Vector2.right * isFacingRightInt(),playerDash.dashDistance);

	}


    //flips the player depending of direction facing. 
    void flipPlayer()
    {
        if ((hor == 1 && isFacingRightBool() == false) || (hor == -1 && isFacingRightBool() == true))
        {
            setIsFacingRight(!isFacingRightBool());
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
    public void setIsFacingRight(bool isF)
    {
        isFacingRight = isF;
    }
    public int isFacingRightInt()
    {
        if (isFacingRight == true)
            return 1;
        else
            return -1;
    }
    public bool isFacingRightBool()
    {
        if (isFacingRight == true)
            return true;
        else
            return false;
    }
    public PlayerState getState()
    {
        return playerState;
    }
    public void setState(PlayerState PS)
    {
        playerState = PS;
        if(playerState == PlayerState.Dead)
        {
            anim.SetTrigger("Die");
        }
    }

}

public enum PlayerState
{
    Moving,
    Dashing,
    Dead
}
