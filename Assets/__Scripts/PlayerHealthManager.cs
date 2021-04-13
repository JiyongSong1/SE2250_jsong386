using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    //initializing max and current player health
    public int playerMaxHp;
    public int playerCurrentHp;

    public HealthBar healthBar;

    //player must start at max health, hence on start, player's current hp is the max hp
    void Start()
    {
        playerCurrentHp = playerMaxHp;
        healthBar.SetMaxHealth(playerMaxHp);        
    }

    //if the player's health is below 0, the player will be deleted
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {            
            setHealth();
        }

        if(playerCurrentHp <= 0)
        {
            gameObject.SetActive(false);

        }

    }

    //player's current hp is decreased by the amount of damage it takes
    public void damagePlayer(int damage)
    {
        playerCurrentHp -= damage;
        healthBar.SetHealth(playerCurrentHp);
    }

    //this sets the health so that player starts with max hp
    public void setHealth()
    {
        playerCurrentHp = playerMaxHp;
        healthBar.SetHealth(playerCurrentHp);
    }
}