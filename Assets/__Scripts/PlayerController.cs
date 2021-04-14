using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Arrow
{
    static public PlayerController S;
    public float moveSpeed;

    public float arrowVelocity = 7.0f;
    
    private Animator anim;

    public Arrow arrow1;

    private bool playerMoving;

    private Vector2 lastMove;
    protected Rigidbody2D myRigidbody;
    public GameObject arrowPrefab;

    private static bool playerExists;

    public string startPoint;

    void Awake()
    {
        //Singleton
        if (S == null)
        {
            S = this;            
        }
        else
        {
            Debug.LogError("Player.Awake() - Attempted to assign second Player.S!");
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

        //check player exists already, and if there is 2 player, then remove one
        if(!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving = false;

        if (Input.GetAxisRaw("Horizontal") > 0.5f ||Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //move player horizontally
            myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidbody.velocity.y);
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);

            //press space to shoot arrows
            if(Input.GetKeyDown(KeyCode.V))
            {
            GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.Euler(0, 0, 90));
            arrow.GetComponent<Rigidbody2D>().velocity = new Vector2 (Input.GetAxisRaw("Horizontal")*arrowVelocity ,0f);
            //destroy arrow after 7 seconds automatically
            Destroy (arrow, 7.0f);
            }
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f ||Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //move playere vertically
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical")* moveSpeed);
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        if(Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
        }
        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);

        
        if(count > 30)
        {
            //double move speed of player when count is over 5
            moveSpeed = 10;
        }

        if(count > 50)
        {
            //double arrow velocity when count is over 14
            arrowVelocity = 14f;
        }
    }
}
