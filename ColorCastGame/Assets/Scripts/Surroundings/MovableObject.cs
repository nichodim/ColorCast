using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public float waitSeconds = 1f;
    public float distanceX = 10f;
    public float distanceY = 0f;
    public float speed = 100f;

    // Make Start a coroutine that begins 
    // as soon as our object is enabled.
    IEnumerator Start()
    {
        // Then, pick our destination point offset from our current location.
        Vector2 targetPosition = new Vector2(transform.position.x + distanceX, transform.position.y + distanceY);
        Debug.Log(targetPosition.ToString()); 

        // Loop until we're within Unity's vector tolerance of our target.
        while (transform.position.x != targetPosition.x || transform.position.y != targetPosition.y)
        {
            Vector2 position2D = new Vector2(transform.position.x, transform.position.y);
            Debug.Log("in while loop");
            // Move one step toward the target at our given speed.
            transform.position = Vector2.MoveTowards(
                  position2D,
                  targetPosition,
                  speed * Time.deltaTime
             );

            yield return new WaitForSeconds(waitSeconds);
        }
        Debug.Log("done while loop");
        // We have arrived. Ensure we hit it exactly.
        transform.position = targetPosition;
    }
}
