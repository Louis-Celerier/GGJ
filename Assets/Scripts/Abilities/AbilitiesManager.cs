using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesManager : MonoBehaviour
{
    [SerializeField] private bool armor;
    [SerializeField] private bool weapon;
    [SerializeField] private bool fireball;
    [SerializeField] private bool dash;
    [SerializeField] private bool doubleJump;
    [SerializeField] private bool shield;

    [SerializeField] private SpriteRenderer _armorRenderer;
    [SerializeField] private SpriteRenderer _weaponRenderer;
    [SerializeField] private SpriteRenderer _shieldRenderer;
    
    void Start()
    {
        
    }

    void Update()
    {
        _armorRenderer.enabled = armor;
        _weaponRenderer.enabled = weapon;
        _shieldRenderer.enabled = shield;
    }
    
}
