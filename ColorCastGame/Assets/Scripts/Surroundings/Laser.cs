using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
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
    private Cast cast;
    public GameObject Character; 

    private void Awake()
    {
        Character = GameObject.Find("Character"); 
        cast = Character.GetComponent<Cast>();
        laserTransform = GetComponent<Transform>();
        emitterLayerMask = LayerMask.GetMask("Default");
    }

    void FixedUpdate()
    {
        cast = Character.GetComponent<Cast>();
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
            if (_hit.point == null)
            {
                Draw2DRay(LaserPointer.position, LaserPointer.position * defaultLaserDistance);
            }
            else
            {
                Draw2DRay(LaserPointer.position, _hit.point);
            }
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
        // Kills the player if colors are opposite
        if (hit.collider.tag == "Player")
        {
            if (gameObject.tag == "groundpurple" && cast.color == "pink")
            {
                Character.SetActive(false);
            }
            else if (gameObject.tag == "groundpink" && cast.color == "purple")
            {
                Character.SetActive(false);
            }
        }
    }
}
