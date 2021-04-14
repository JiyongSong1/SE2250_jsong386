using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    //declaring variables
       private BoxCollider2D bounds;
    private CameraController theCamera;


    //setting bounard for the house
    void Start()
    {
        bounds = GetComponent<BoxCollider2D>();
        theCamera = FindObjectOfType<CameraController>();
        theCamera.SetBounds(bounds);
    }

}