using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParingAbility : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Collider _collider;

    public float paringDelay = 0.5f;
    
    private bool shieldInput = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shieldInput = Input.GetKeyDown(KeyCode.H);

        if (shieldInput)
        {
            _sprite.enabled = true;
            _collider.enabled = true;
            
            StartCoroutine(StopParing());
        }
    }

    IEnumerator StopParing()
    {
        yield return new WaitForSeconds(paringDelay);
        _sprite.enabled = false;
        _collider.enabled = false;
    }
}
