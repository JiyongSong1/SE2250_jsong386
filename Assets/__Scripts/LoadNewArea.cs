using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewArea : MonoBehaviour
{
    public string levelToLoad;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = Arrow.count;
    }


    //player is allowed enter when over 50 points
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(score > 50 && other.gameObject.name == "Player")
        {
            Application.LoadLevel(levelToLoad);
        }
    }
}
