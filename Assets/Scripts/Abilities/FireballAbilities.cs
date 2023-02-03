using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAbilities : MonoBehaviour
{
    [SerializeField] private GameObject FireballPrefab;
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private Transform _fireballSocketR;
    [SerializeField] private Transform _fireballSocketL;
    
    private bool _canFire = true;
    
    public float Speed = 10.0f;
    public float FireCD = 1.0f;

    private float _fireTimer;

    private PlayerController _playerController;
    private PlayerAnimator _playerAnimator;

    void Start()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();
        _playerController = GetComponent<PlayerController>();
    }
    
    // Update is called once per frame
    void Update()
    {
        var abilityInput = Input.GetKey(KeyCode.E);

        if (!_canFire)
        {
            _fireTimer += Time.fixedDeltaTime;
            if (_fireTimer >= FireCD)
            {
                _fireTimer = 0;
                _canFire = true;
            }
        }

        if (abilityInput && _canFire)
        {
            _canFire = false;
            
            _playerAnimator.PlayFireAnimation();

            Transform socket;
            if (_playerController.dirRight)
            {
                FireballPrefab.GetComponent<SpriteRenderer>().flipX = false;
                socket = _fireballSocketR;
            } else {
                FireballPrefab.GetComponent<SpriteRenderer>().flipX = true;
                socket = _fireballSocketL;
            }

            var fireball_obj = Instantiate(FireballPrefab, socket.position, Quaternion.identity);
            var projectile = fireball_obj.GetComponent<Projectile>();
            
            Vector3 vel = new Vector3(_rb.transform.localScale.x, 0, 0) * Speed * (_playerController.dirRight ? 1 : -1);
            projectile.SetVelocity(vel);
        }
    }
}
