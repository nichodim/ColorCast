using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor : MonoBehaviour
{
    private Cast cast;
    public Camera cam; 

    void Start()
    {
        //cam = GetComponent<Camera>(); 
        cast = GetComponent<Cast>();
        BackgroundCast(cast.color); 
    }

    void FixedUpdate()
    {
        cast = GetComponent<Cast>();
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            BackgroundCast(cast.color);
        }
    }

    void BackgroundCast(string color)
    {
        if (color == "Pink")
        {
            cam.backgroundColor = new Color(65, 1, 38, 0);
        }
        else if (color == "Purple")
        {
            cam.backgroundColor = new Color(18, 10, 70, 0);
            //GetComponent<Camera>()
        }
    }
}
