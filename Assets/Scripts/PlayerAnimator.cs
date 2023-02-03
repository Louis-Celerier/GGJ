using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private SpriteRenderer _armorRenderer;
    [SerializeField] private SpriteRenderer _swordRenderer;
    [SerializeField] private SpriteRenderer _shieldRenderer;
    
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
        _armorRenderer.flipX = _playerController.dirRight;
        _swordRenderer.flipX = _playerController.dirRight;
        _shieldRenderer.flipX = _playerController.dirRight;
        
        _animator.SetBool("isRun", Mathf.Abs(_rb.velocity.x) > 0.5f);
        _animator.SetBool("isJump", !_playerController.IsGrounded());
    }

    public void PlayFireAnimation()
    {
        _animator.Play("CrocoFire");
    }
}
