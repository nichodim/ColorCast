using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Laser distance
    [SerializeField] private float defaultLaserDistance = 50f;

    // Relevant info
    public Transform LaserPointer;
    public LineRenderer LaserRenderer;
    private Transform laserTransform;

    private void Awake()
    {
        laserTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        ShootLaser();
    }

    void ShootLaser()
    {
        // Draw laser
        if (Physics2D.Raycast(laserTransform.position, transform.right))
        {
            RaycastHit2D _hit = Physics2D.Raycast(laserTransform.position, transform.right);
            Draw2DRay(LaserPointer.position, _hit.point);
            Debug.Log("Drawhit"); 
        }
        // Fire line that hits entities
        if (Physics2D.Raycast(laserTransform.position, transform.right, defaultLaserDistance))
        {
            RaycastHit2D hit = Physics2D.Raycast(laserTransform.position, transform.right, defaultLaserDistance);
            if (hit.collider.tag == "Player")
            {
                LaserHit();
                Debug.Log("Playerhit"); 
            }
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        Debug.Log("startPos: " + startPos + "\nendPos: " + endPos); 
        LaserRenderer.SetPosition(0, startPos);
        LaserRenderer.SetPosition(1, endPos);
    }

    void LaserHit()
    {
        GameObject.Find("Character").SetActive(false);
    }
}
