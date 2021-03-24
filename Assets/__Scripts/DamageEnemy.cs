using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        //Enemy is destroyed if hit by a weapon
        if(other.gameObject.tag == "Enemy")
        {
            Destroy (other.gameObject);
        }
    }
}
