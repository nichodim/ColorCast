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
    private int emitterLayerMask;

    private void Awake()
    {
        laserTransform = GetComponent<Transform>();
        emitterLayerMask = LayerMask.GetMask("Default");
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
        }
        // Fire line that hits entities
        if (Physics2D.Raycast(laserTransform.position, transform.right, defaultLaserDistance, emitterLayerMask))
        {
            RaycastHit2D hit = Physics2D.Raycast(laserTransform.position, transform.right, defaultLaserDistance, emitterLayerMask);
            LaserHit(hit);
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    { 
        LaserRenderer.SetPosition(0, startPos);
        LaserRenderer.SetPosition(1, endPos);
    }

    void LaserHit(RaycastHit2D hit)
    {
        if (hit.collider.tag == "Player")
        {
            GameObject.Find("Character").SetActive(false);
        }
    // TODO replace system with specific color lasers that work accordingly
    }
}
