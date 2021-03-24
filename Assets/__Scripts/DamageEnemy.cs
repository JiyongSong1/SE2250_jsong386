using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    SpriteRenderer sprite;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {        
        if(counter>= 3)
        {            
            // Change the 'color' property of the 'Sprite Renderer'
            sprite.color = new Color (1, 0, 0, 1); 
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        //Enemy is destroyed if hit by a weapon
        if(other.gameObject.tag == "Enemy")
        {
            Destroy (other.gameObject);
            counter++;
        }
    }
}
