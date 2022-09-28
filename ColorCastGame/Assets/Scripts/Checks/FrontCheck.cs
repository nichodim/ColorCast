using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontCheck : MonoBehaviour
{
    public bool isTouchingFront = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isTouchingFront = true;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        isTouchingFront = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isTouchingFront = false;
    }
    void Update()
    {
        Debug.Log(isTouchingFront.ToString());
    }
}
