using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    float moveSpeed = 5f;
    Rigidbody2D rigidbody;

    public int damage;
    public GameObject target;
    Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        //fireball automatically targets the player
        target = GameObject.Find("Player");
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y);
        //destroy fireball object after 5 seconds
        Destroy(gameObject, 5f);
    }

    //collision detection
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            //passes damage to health manager
            col.gameObject.GetComponent<PlayerHealthManager>().damagePlayer(damage);
            Destroy (gameObject);
        }
    }
}
