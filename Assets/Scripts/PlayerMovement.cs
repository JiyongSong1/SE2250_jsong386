using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float dashDistance = 15f;
    bool isDashing;
    float doubleTapTime;

    //private Rigidbody2D myRigidbody; in player controller
    private Rigidbody2D rb;
    KeyCode lastKeyCode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Dashing left
        if (Input.GetKeyDown(lastKeyCode.A){
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A){
                //dash
                StartCoroutine(Dash(-1f));
            } else {
                doubleTapTime = Time.time + 0.3f;
            }

            lastKeyCode keyCode.A;
        }
        //Dashing right
        if (Input.GetKeyDown(lastKeyCode.D){
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D){
                //dash
                StartCoroutine(Dash(1f));
            } else {
                doubleTapTime = Time.time + 0.3f;
            }

            lastKeyCode keyCode.D;
        }
    }
    IEnumerator Dash (float direction) {
        isDashing = true;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.4f);
        isDashing = false;
    }
    
}
