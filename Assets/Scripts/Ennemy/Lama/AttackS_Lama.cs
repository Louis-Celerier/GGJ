using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AttackS_Lama : StateMachineBehaviour
{
    public GameObject attackPrefab;
    public float attackingRange = 3f;
    public float speed = 10.0f;
    public float frequence = 1.0f;
    private GameObject attack;
    private Transform player;
    private Projectile projectile;
    private float timer = 0;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);
        float distance = Vector2.Distance(player.position, animator.transform.position);
        if (distance > attackingRange) animator.SetBool("isAttacking", false);

        if (frequence < timer)
        {
            timer = 0;
            attack = Instantiate(attackPrefab, animator.transform.position, Quaternion.identity);
            Projectile projectile = attack.GetComponent<Projectile>();

            Vector3 vel = new Vector3(1, 0, 0) * speed * (player.position.x > animator.transform.position.x ? 1 : -1);
            projectile.SetVelocity(vel);
        }
        else timer += Time.deltaTime;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}