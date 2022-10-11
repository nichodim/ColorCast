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
        if (collision.gameObject.name == "Tilemap1")
        {
            if (cast.color == "pink")
            {
                Destroy(gameObject); 
            }
        }
        // Tilemap2 is pink
        else if (collision.gameObject.name == "Tilemap2")
        {
            if (cast.color == "purple")
            {
                Destroy(gameObject);
            }
        }
    }
}
