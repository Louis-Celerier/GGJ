using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class PlayerController : MonoBehaviour
{
    [Header("General Parameter")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private BoxCollider _collider;
    
    [Header("Controller Parameter")]
    public float Speed = 10.0f;
    public float gravityStrength = 9.8f;
    
    private float horizontal;
    private Vector3 movement;
    
    [Header("Jump Parameter")]
    public float JumpForce = 2.0f;

    private float distToGround;

    private bool canJump = false;
    private bool doubleJump = false;

    [Header("Dashing Parameter")] 
    [SerializeField] private float _dashingVelocity = 14f;
    [SerializeField] private float _dashingTime = 0.5f;

    private Vector2 _dashDir;
    private bool _isDashing;
    private bool _canDash = true;

    public bool dirRight = true;

    public PlayerAnimator _playerAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();   
        distToGround = _collider.size.y/2 * transform.localScale.y;
    }

    private void FixedUpdate()
    {
        _rb.velocity += new Vector3(0, -gravityStrength * Time.fixedDeltaTime, 0);
    }

    // Update is called once per frame
    void Update()
    {   
        horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0) dirRight = true;
        else if (horizontal < 0) dirRight = false;
        
        var dashInput = Input.GetKeyDown(KeyCode.F);

        if (IsGrounded())
        {
            _canDash = true;
            canJump = true;
        }
        else
        {
            canJump = false;
        }
        
        if (dashInput && _canDash)
        {
            _isDashing = true;
            _canDash = false;
            
            //Offer a jump after the dash
            doubleJump = true;

            _dashDir = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            if (_dashDir == Vector2.zero)
            {
                _dashDir = new Vector2(transform.localScale.x, 0);
            }

            StartCoroutine(StopDashing());
        }

        if (_isDashing)
        {
            _playerAnimator.PlayDashAnimation();
            _rb.velocity = _dashDir.normalized * _dashingVelocity;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump)
            {
                doubleJump = true;
                _rb.velocity = new Vector3(_rb.velocity.x, JumpForce, _rb.velocity.z);
                _playerAnimator.PlayJumpAnimation();
            } else if (doubleJump)
            {
                doubleJump = false;
                _rb.velocity = new Vector3(_rb.velocity.x, JumpForce, _rb.velocity.z);
                _playerAnimator.PlayJumpAnimation();
            }
        }

        if(!_isDashing)
            _rb.velocity = new Vector3(horizontal * Speed, _rb.velocity.y, _rb.velocity.z);
    }
    
    public bool IsGrounded()
    {
        Debug.DrawLine(_rb.position, _rb.position + Vector3.down * (distToGround + 0.40f));
        return Physics.Raycast(_rb.position, Vector3.down, distToGround + 0.40f);
    }

    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(_dashingTime);
        _isDashing = false;
    }
    
}
