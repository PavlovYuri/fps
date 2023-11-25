using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    float timer;
    float timeToPatrol = 5.0f;
    Transform hero;
    float chaseRange = 10.0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        hero = GameObject.FindGameObjectWithTag("Hero").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > timeToPatrol) animator.SetBool("isPatrolling", true);

        float distance = Vector3.Distance(animator.transform.position, hero.transform.position);
        if (distance < chaseRange) animator.SetBool("isChasing", true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
