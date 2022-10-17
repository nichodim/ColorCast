using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor : MonoBehaviour
{
    public Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        BackgroundCast(FindObjectOfType<Cast>().color);
    }

    void BackgroundCast(string color)
    {
        if (color == "pink")
        {
            cam.backgroundColor = new Color(0.255f, 0.004f, 0.149f, 1f);
        }
        else if (color == "purple")
        {
            cam.backgroundColor = new Color(0.075f, 0.043f, 0.275f, 1f); 
        }
    }
}
