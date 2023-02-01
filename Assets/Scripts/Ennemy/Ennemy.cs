using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public int HP = 600;
    public int attackPoints = 50;
    public Animator animator;
    private GameObject player;
    private bool canReceive = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void TakeDamages(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
        }
        else animator.SetTrigger("damage");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            /*if (player.isAttacking && canReceive)
            {
                TakeDamages(player.attackPoints);
                canReceive = false;
            }
            if (!player.isAttacking) canReceive = true;*/
        }
    }
}