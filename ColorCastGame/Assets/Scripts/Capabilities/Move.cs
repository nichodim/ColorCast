using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private InputController input = null; 
    [SerializeField, Range(0f, 100f)] private float _maxSpeed = 4f;
    [SerializeField, Range(0f, 100f)] private float _maxAcceleration = 35f;
    [SerializeField, Range(0f, 100f)] private float _maxAirAcceleration = 20f;
    [SerializeField] private LayerMask layermask;

    private Vector2 _direction, _desiredVelocity, _velocity;
    private Rigidbody2D _body;
    private Ground _ground;
    private bool isFacingRight = true;

    //wallclimbvariables
    /*
    private bool wallSliding;
    public float wallSlidingSpeed;
    private bool isTouchingFront;*/
    public Transform FrontCheck;
    //public LayerMask ground; 

    //dashvariables
    private bool canDash = true;
    public bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.3f;
    private float preDashSpeed;
    private bool doneDash = true; 
    [SerializeField] private TrailRenderer tr; 

    private float _maxSpeedChange, _acceleration;
    private bool _onGround;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _ground = GetComponent<Ground>();
    }

    private void Update()
    {
        if (isDashing)
        {
            return; 
        }

        if (_ground.onGround && doneDash)
        {
            canDash = true; 
        }

        Flip(); 
        _direction.x = input.RetrieveMoveInput();
        _desiredVelocity = new Vector2(_direction.x, 0f) * Mathf.Max(_maxSpeed - _ground.friction, 0f);
        
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash()); 
        }

        /*isTouchingFront = Physics2D.OverlapCircle(FrontCheck.position, new Vector2(0.3f, 1f), 0, GameObject.FindWithTag("ground"));
        if (isTouchingFront && !_ground.onGround && input.RetrieveMoveInput() != 0)
        {
            wallSliding = true; 
        }
        else
        {
            wallSliding = false;
        }*/

        Debug.Log(Physics2D.OverlapCircle(FrontCheck.position, 0.5f, layermask));
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        _onGround = _ground.GetOnGround();
        _velocity = _body.velocity;

        _acceleration = _onGround ? _maxAcceleration : _maxAirAcceleration;
        _maxSpeedChange = _acceleration * Time.deltaTime;
        _velocity.x = Mathf.MoveTowards(_velocity.x, _desiredVelocity.x, _maxSpeedChange);

        _body.velocity = _velocity;

        /*if (wallSliding)
        {
            _body.velocity = new Vector2(_body.velocity.y, Mathf.Clamp(_body.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }*/
    }

    private void Flip()
    {
        if (isFacingRight && input.RetrieveMoveInput() < 0f || !isFacingRight && input.RetrieveMoveInput() > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale; 
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        doneDash = false; 
        float originalGravity = _body.gravityScale;
        preDashSpeed = _body.velocity.x; 
        _body.gravityScale = 0f;
        _body.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        _body.gravityScale = originalGravity;
        _body.velocity =  new Vector2(preDashSpeed, 0f);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        doneDash = true; 
    }
    //FindObjectOfType<FrontCheck>().isTouchingFront
}
