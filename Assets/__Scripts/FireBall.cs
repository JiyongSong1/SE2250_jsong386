using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    float moveSpeed = 3f;
    Rigidbody2D rigidbody;

    public GameObject target;
    Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player");
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            Destroy (gameObject);
        }
    }
}
