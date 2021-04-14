using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public static int count;

    public Text countText;

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        countText.text = "Count: " + count.ToString();
        //changed animations
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)){
            count += 10;
            setCountText();
        }
    }

    //collision detection and updates scores
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy (col.gameObject);
            count += 1;
            setCountText();
        } else if (col.gameObject.tag == "Mage")
        {
            Destroy (col.gameObject);
            count += 2;
            setCountText();
        }
    }

    //sets the test
    public void setCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
