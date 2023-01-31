using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAbilities : MonoBehaviour
{
    [SerializeField] private GameObject FireballPrefab;
    [SerializeField] private Rigidbody _rb;

    private bool _canFire = true;
    
    public float Speed = 10.0f;
    public float FireCD = 1.0f;

    private float _fireTimer;

    // Update is called once per frame
    void Update()
    {
        var abilityInput = Input.GetKey(KeyCode.E);
        
        Debug.Log(_fireTimer);

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
            
            var fireball_obj = Instantiate(FireballPrefab, _rb.position, Quaternion.identity);
            var projectile = fireball_obj.GetComponent<Projectile>();

            Vector3 vel = new Vector3(_rb.transform.localScale.x, 0, 0) * Speed;
            projectile.SetVelocity(vel);
        }
    }
}
