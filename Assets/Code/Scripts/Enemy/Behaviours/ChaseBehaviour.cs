using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseBehaviour : StateMachineBehaviour
{
    EnemyCharacter enemyCharacter;
    NavMeshAgent agent;
    Transform hero;
    float attackRange = 5.0f;
    float chaseRange = 10.0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyCharacter = animator.GetComponent<EnemyCharacter>();
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 6.0f;

        hero = GameObject.FindGameObjectWithTag("Hero").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(hero.position);
        float distance = Vector3.Distance(animator.transform.position, hero.position);

        if (distance < attackRange) 
        {
            animator.SetBool("isAttacking", true);
            enemyCharacter.Attack();
        }

        if (distance > chaseRange) animator.SetBool("isChasing", false); 
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
        agent.speed = 3.5f;
    }

}
