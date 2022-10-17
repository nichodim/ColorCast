using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    /*public float waitSeconds = 1f;
    public float distanceX = 1f; 
    public Vector2 targetOffset = Vector2.right * distanceX;
    public float speed = 1f;

    // Make Start a coroutine that begins 
    // as soon as our object is enabled.
    IEnumerator Start()
    {
        // Then, pick our destination point offset from our current location.
        Vector2 targetPosition = transform.position + targetOffset;

        // Loop until we're within Unity's vector tolerance of our target.
        while (transform.position != targetPosition)
        {

            // Move one step toward the target at our given speed.
            transform.position = Vector2.MoveTowards(
                  transform.position,
                  targetPosition,
                  speed * Time.deltaTime
             );

            yield return new WaitForSeconds(waitSeconds);
        }

        // We have arrived. Ensure we hit it exactly.
        transform.position = targetPosition;
    }*/
}
