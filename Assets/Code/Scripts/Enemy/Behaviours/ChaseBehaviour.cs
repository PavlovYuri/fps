using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviour : StateMachineBehaviour
{
    EnemyCharacter enemyCharacter;
    EnemyMovement enemyMovement;
    Transform hero;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyCharacter = animator.GetComponent<EnemyCharacter>();
        enemyMovement = animator.GetComponent<EnemyMovement>();

        hero = GameObject.FindGameObjectWithTag("Hero").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyMovement.SetDestination(hero.position);
        float distance = Vector3.Distance(animator.transform.position, hero.position);

        if (distance < enemyMovement.attackRange) 
        {
            animator.SetBool("isAttacking", true);
            enemyCharacter.Attack();
        }

        if (distance > enemyMovement.chaseRange) animator.SetBool("isChasing", false); 
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyMovement.SetDestination(enemyMovement.transform.position);
        enemyMovement.speed = 3.5f;
    }

}
