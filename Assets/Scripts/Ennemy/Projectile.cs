using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    public void SetVelocity(Vector3 vel)
    {
        _rb.velocity = vel;
    }

    void Start()
    {
        StartCoroutine(ProjCD());
    }


    IEnumerator ProjCD()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }

}