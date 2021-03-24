﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    private bool moving;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float moveTime;
    private float moveTimeCounter;
    private Vector3 moveDirection;

    public float reloadWait;
    private bool reloading;
    private GameObject player;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        
        //timeBetweenMoveCounter = timeBetweenMove;
        //moveTimeCounter = moveTime;

        timeBetweenMoveCounter = Random.Range(timeBetweenMove*0.75f, timeBetweenMove*1.5f);
        moveTimeCounter = Random.Range(moveTime*0.75f, timeBetweenMove*1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            moveTimeCounter -= Time.deltaTime;
            myRigidbody.velocity = moveDirection;

            if (moveTimeCounter < 0f)
            {
                moving = false;
                //timeBetweenMoveCounter = timeBetweenMove;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove*0.75f, timeBetweenMove*1.5f);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;

            if(timeBetweenMoveCounter < 0f)
            {
                moving = true;
                //moveTimeCounter = moveTime;
                moveTimeCounter = Random.Range(moveTime*0.75f, timeBetweenMove*1.5f);
                //move slime randomly
                moveDirection = new Vector3 (Random.Range (-1f, 1f)*moveSpeed, Random.Range (-1f, 1f)*moveSpeed, 0f);
            }
        }

        if(reloading)
        {
            reloadWait -= Time.deltaTime;
            if(reloadWait < 0)
            {
                Application.LoadLevel(Application.loadedLevel);
                player.SetActive(true);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Player")
        {
            other.gameObject.SetActive(false);
            reloading = true;
            player = other.gameObject;
        }
    }
}