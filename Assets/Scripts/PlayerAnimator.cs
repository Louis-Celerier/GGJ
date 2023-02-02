using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rb;

    private PlayerController _playerController;

    void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }
    
    // Update is called once per frame
    void Update()
    {
        _renderer.flipX = _playerController.dirRight;
        
        _animator.SetBool("isRun", Mathf.Abs(_rb.velocity.x) > 0);
    }
}
