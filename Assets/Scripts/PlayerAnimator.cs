using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private SpriteRenderer _armorRenderer;
    [SerializeField] private SpriteRenderer _swordRenderer;
    [SerializeField] private SpriteRenderer _shieldRenderer;
    [SerializeField] private SpriteRenderer _effectRenderer;
    
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
        _effectRenderer.flipX = _playerController.dirRight;
        
        _animator.SetBool("isRun", Mathf.Abs(_rb.velocity.x) > 0.5f);
        _animator.SetBool("isGround", _playerController.IsGrounded());
    }

    public void PlayFireAnimation()
    {
        _animator.Play("CrocoFire");
    }

    public void PlayJumpAnimation()
    {
        _animator.Play("CrocoJump");
    }
    
    public void PlayMeleeAttackAnimation()
    {
        _animator.Play("CrocoAttack");
    }

    public void PlayParingAnimation()
    {
        _animator.Play("CrocoGarde");
    }

    public void PlayDashAnimation()
    {
        _animator.Play("CrocoDash");
    }
    
}
