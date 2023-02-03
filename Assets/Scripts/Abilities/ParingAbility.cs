using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParingAbility : MonoBehaviour
{
    private PlayerAnimator _playerAnimator;

    public float paringDelay = 0.5f;
    
    private bool shieldInput = false;
    
    void Start()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();
    }
    
    void Update()
    {
        shieldInput = Input.GetKeyDown(KeyCode.H);

        if (shieldInput)
        {
            _playerAnimator.PlayParingAnimation();
            
            StartCoroutine(StopParing());
        }
    }

    IEnumerator StopParing()
    {
        yield return new WaitForSeconds(paringDelay);
    }
}
