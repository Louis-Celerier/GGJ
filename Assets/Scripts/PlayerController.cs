using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class PlayerController : MonoBehaviour
{
    public float Speed = 10.0f;
    public float JumpForce = 2.0f;
    public float gravityStrength = 9.8f;

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private BoxCollider _collider;

    private float horizontal;
    private Vector3 movement;
    private float distToGround;

    private bool canJump = false;
    private bool doubleJump = false;
    
    // Start is called before the first frame update
    void Start()
    {
        distToGround = _collider.size.y/2;
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(0, _rb.velocity.y, _rb.velocity.z);
        _rb.velocity += new Vector3(horizontal * Speed, -gravityStrength * Time.fixedDeltaTime, 0);
    }

    // Update is called once per frame
    void Update()
    {   
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                doubleJump = true;
                _rb.velocity = new Vector3(_rb.velocity.x, JumpForce, _rb.velocity.z);
            } else if (doubleJump)
            {
                doubleJump = false;
                _rb.velocity = new Vector3(_rb.velocity.x, JumpForce, _rb.velocity.z);
            }
        }
    }
    
    bool IsGrounded()
    {
        return Physics.Raycast(_rb.position, Vector3.down, distToGround + 0.07f);
    }
    
}
