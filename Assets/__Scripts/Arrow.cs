using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    //initializing the static, text, and GameObject fields
    public static int count;
    public Text countText;
    public GameObject target;

    // Start is called before the first frame update
    // Set count to 0 first as you start with 0 points and then display "Count: Score"
    void Start()
    {
        count = 0;
        countText.text = "Count: " + count.ToString();
        //changed animations
    }

    //Update is called every frame
    //Keeps track of count total
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)){
            count += 10;
            setCountText();
        }
    }

    //collision detection 
    //update count for every enemy destroyed
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

    //sets the text
    public void setCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
