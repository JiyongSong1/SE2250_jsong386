using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    //initializing the int damage
    public int damage;

    void Start()
    {

    }

    void Update()
    {

    }

    //This detects the 2d collision and if the gameObject and the other gameObject collide, then the player's health will decrease by "damage" everytime they collide
    void OnCollision(Collision2D other)
    {
        if(other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damage);
        }
    }
}