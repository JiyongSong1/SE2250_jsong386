using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : PlayerController
{

    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    // Start is called before the first frame update
    void Start()
    {
     myRigidbody = GetComponent<Rigidbody2D>();
     dashTime =startDashTime;   
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == 0){
            if(Input.GetKeyDown(KeyCode.J)){
                direction = 1;
            } else if(Input.GetKeyDown(KeyCode.L)){
                direction = 2;
            } else if(Input.GetKeyDown(KeyCode.I)){
                direction = 3;
            } else if(Input.GetKeyDown(KeyCode.K)){
                direction = 4;
            }
        } else {
            if (dashTime <= 0){
                direction =0;
                dashTime = startDashTime;
                myRigidbody.velocity = Vector2.zero;
            } else{
                dashTime -= Time.deltaTime;

                if(direction == 1){
                    myRigidbody.velocity = Vector2.left * dashSpeed;
                } else if (direction == 2){
                    myRigidbody.velocity = Vector2.right * dashSpeed;
                } else if (direction == 3){
                    myRigidbody.velocity = Vector2.up * dashSpeed;
                } else if (direction == 4){
                    myRigidbody.velocity = Vector2.down * dashSpeed;
                }
            }
        }
    }
}