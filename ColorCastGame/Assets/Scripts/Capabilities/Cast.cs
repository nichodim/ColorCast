using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cast : MonoBehaviour
{
    public Material Pink;
    public Material Purple;

    public string color = "pink";

    // Initiates player with color
    void Start()
    {
        if (color == "pink")
        {
            ColorCast(Pink);
        }
        else if (color == "purple")
        {
            ColorCast(Purple);
        }
    }

    // Casts opposite color
    void Update()
    {
        // Casts character with opposite color (between pink and purple)
        if (Input.GetKeyDown("w"))
        {
            if (color == "pink")
            {
                color = "purple";
                ColorCast(Purple);  
            }
            else if (color == "purple")
            {
                color = "pink";
                ColorCast(Pink); 
            }
        }
    }

    void ColorCast(Material color)
    {
        GameObject.Find("Character").GetComponent<Renderer>().material = color;
        GameObject.Find("Character").GetComponent<TrailRenderer>().material = color;
    }
}
