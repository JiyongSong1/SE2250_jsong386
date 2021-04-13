using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaAttack : MonoBehaviour
{
    [SerializeField]
    GameObject fireBall;

    float fireRate;
    float nextFire;
    void Start()
    {
        fireRate = 3f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTimeForFire();
    }
    
    void CheckTimeForFire()
    {
        if (Time.time > nextFire){
            Instantiate (fireBall, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
