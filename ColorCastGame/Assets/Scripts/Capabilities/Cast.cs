using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cast : MonoBehaviour
{
    public Material Pink;
    public Material Purple;

    public string color;

    // Initiates player with color
    void Start()
    {
        color = "pink";
        ColorCast(Pink); 
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (color == "pink")
            {
                color = "purple";
                //GameObject.Find("Character").GetComponent<Renderer>().material.color = new Color(52, 32, 176);
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
    }
}
