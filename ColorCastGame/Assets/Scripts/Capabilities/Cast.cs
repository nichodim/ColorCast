using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cast : MonoBehaviour
{
    public string color;

    // Initiates player with color
    // TODO add asset change with color name change
    void Start()
    {
        color = "pink"; 
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (color == "pink")
            {
                color = "purple"; 
            }
            else if (color == "purple")
            {
                color = "pink"; 
            }
        }
    }
}
