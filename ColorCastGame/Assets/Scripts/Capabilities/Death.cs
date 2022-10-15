using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Cast cast;
    
    void Start()
    {
        cast = GetComponent<Cast>();
    }

    void FixedUpdate()
    {
        cast = GetComponent<Cast>(); 
    }

    // Kills character when colliding with opposing color tilemap
    private void OnCollisionStay2D(Collision2D collision)
    {
        // Tilemap1 is purple
        if (collision.gameObject.tag == "groundpurple")
        {
            if (cast.color == "pink")
            {
                //Destroy(gameObject); 
                gameObject.SetActive(false); 
            }
        }
        // Tilemap2 is pink
        else if (collision.gameObject.tag == "groundpink")
        {
            if (cast.color == "purple")
            {
                //Destroy(gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}
