using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private InputController input = null; 
    [SerializeField, Range(0f, 10f)] private float _jumpHeight = 3f;
    [SerializeField, Range(0, 5)] private int _maxAirJumps = 0;
    [SerializeField, Range(0f, 5f)] private float _downwardMovementMultiplier = 3f;
    [SerializeField, Range(0f, 5f)] private float _upwardMovementMultiplier = 1.7f;
    [SerializeField, Range(0, 0.3f)] private float _cayoteTime = 0.2f;
    [SerializeField, Range(0f, 0.3f)] private float _jumpBufferTime = 0.2f;

    private Rigidbody2D _body;
    private Ground _ground;
    private Vector2 _velocity;

    private int _jumpPhase;
    private float _defaultGravityScale, _jumpSpeed, _cayoteCounter, _jumpBufferCounter;

    private bool _desiredJump, _onGround, _isJumping;


    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _ground = GetComponent<Ground>();

        _defaultGravityScale = 1f;
    }

    void Update()
    {
        _desiredJump |= input.RetrieveJumpInput();
    }

    private void FixedUpdate()
    {
        _onGround = _ground.onGround;
        _velocity = _body.velocity;

        if (_onGround && _body.velocity.y == 0)
        {
            _jumpPhase = 0;
            _cayoteCounter = _cayoteTime;
            _isJumping = false; 
        }
        else
        {
            _cayoteCounter -= Time.deltaTime; 
        }

        if (_desiredJump)
        {
            _desiredJump = false;
            _jumpBufferCounter = _jumpBufferTime; 
        }
        else if (!_desiredJump && _jumpBufferCounter > 0)
        {
            _jumpBufferCounter -= Time.deltaTime; 
        }

        if (_jumpBufferCounter > 0)
        {
            JumpAction(); 
        }

        if (!FindObjectOfType<Move>().isDashing)
        {
            if (input.RetrieveJumpHoldInput() && _body.velocity.y > 0)
            {
                _body.gravityScale = _upwardMovementMultiplier;
            }
            else if (!input.RetrieveJumpHoldInput() || _body.velocity.y < 0)
            {
                _body.gravityScale = _downwardMovementMultiplier;
            }
            else if (_body.velocity.y == 0)
            {
                _body.gravityScale = _defaultGravityScale;
            }
        }

        _body.velocity = _velocity;
    }
    private void JumpAction()
    {
        if (_cayoteCounter > 0f || _jumpPhase < _maxAirJumps /*&& _isJumping*/)
        {
            if (_isJumping || !_onGround)
            {
                _jumpPhase += 1;
            }

            _jumpBufferCounter = 0; 
            _cayoteCounter = 0; 
            _jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * _jumpHeight);
            _isJumping = true; 

            if (_velocity.y > 0f)
            {
                _jumpSpeed = Mathf.Max(_jumpSpeed - _velocity.y, 0f);
            }
            else if (_velocity.y < 0f)
            {
                _jumpSpeed += Mathf.Abs(_body.velocity.y);
            }
            _velocity.y += _jumpSpeed;
        }
    }
}
