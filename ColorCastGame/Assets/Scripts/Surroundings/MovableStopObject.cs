using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableStopObject : MonoBehaviour
{
    public float flipTime = 0f;
    public float collidedTime = 0.01f; 
    public float distanceX = 0f;
    public float distanceY = 0f;
    public float speed = 3f;
    private bool onObject = false; 

    // Make Start a coroutine that begins 
    // as soon as our object is enabled.
    IEnumerator Start()
    {
        // Then, pick our destination point offset from our current location.
        Vector2 targetPosition = new Vector2(transform.position.x + distanceX, transform.position.y + distanceY);
        // Save the initial position of object
        Vector2 initialposition = new Vector2(transform.position.x, transform.position.y);

        while (true)
        {
            // Loop until we're within Unity's vector tolerance of our target.
            while (transform.position.x != targetPosition.x || transform.position.y != targetPosition.y)
            {
                Vector2 currentposition2D = new Vector2(transform.position.x, transform.position.y);

                // Stops object
                while (onObject == true)
                {
                    yield return new WaitForSeconds(collidedTime);
                }

                // Move one step toward the target at our given speed.
                transform.position = Vector2.MoveTowards(
                      currentposition2D,
                      targetPosition,
                      speed * Time.deltaTime
                 );

                //Usually keep at 0 for smooth movement
                yield return new WaitForSeconds(flipTime);
            }
            // We have arrived. Ensure we hit it exactly.
            transform.position = targetPosition;

            // Reverse the object
            while (transform.position.x != initialposition.x || transform.position.y != initialposition.y)
            {
                Vector2 currentposition2D = new Vector2(transform.position.x, transform.position.y);

                // Stops object
                while (onObject == true)
                {
                    yield return new WaitForSeconds(collidedTime);
                }

                // Move one step toward the target at our given speed.
                transform.position = Vector2.MoveTowards(
                      currentposition2D,
                      initialposition,
                      speed * Time.deltaTime
                 );

                //Usually keep at 0 for smooth movement
                yield return new WaitForSeconds(flipTime);
            }
            // We have arrived. Ensure we hit it exactly.
            transform.position = initialposition;
        }
    }

    // Detects collision with the player and changes boolean to stop movement
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            onObject = true;
        }
        else
        {
            onObject = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            onObject = false;
        }
    }
}
