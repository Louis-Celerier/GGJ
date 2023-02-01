using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAbilities : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sword;
    [SerializeField] private Collider _collider;
    
    public float delayAttack = 0.3f;
    
    private bool attackInput;
    
    void Update()
    {
        attackInput = Input.GetKeyDown(KeyCode.G);

        if (attackInput)
        {
            sword.enabled = true;
            _collider.enabled = true;

            StartCoroutine(StopAttack());
        }
    }

    IEnumerator StopAttack()
    {
        yield return new WaitForSeconds(delayAttack);
        sword.enabled = false;
        _collider.enabled = false;

    }
}
