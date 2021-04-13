using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        //changed animations
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy (col.gameObject);
            Destroy (gameObject);
        }
    }
}