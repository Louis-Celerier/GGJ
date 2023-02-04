using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAbilities : MonoBehaviour
{
    
    private PlayerAnimator _playerAnimator;
    
    public float delayAttack = 0.3f;
    
    private bool attackInput;

    void Start()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();
    }
    
    void Update()
    {
        attackInput = Input.GetKeyDown(KeyCode.G);

        if (attackInput)
        {   
            _playerAnimator.PlayMeleeAttackAnimation();
            
            StartCoroutine(StopAttack());
        }
    }

    IEnumerator StopAttack()
    {
        yield return new WaitForSeconds(delayAttack);
    }
}
