using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
    float timer;
    float timeToIdle = 10.0f;

    EnemyMovement enemyMovement;
    Vector3 target;
    List<Transform> points = new List<Transform>();
    

    Transform hero;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        Transform pointsObject = enemyMovement.enemyPoints.transform;
        foreach (Transform t in pointsObject) 
        {
            points.Add(t);
        }

        enemyMovement = animator.GetComponent<EnemyMovement>();
        enemyMovement.SetDestination(animator.transform.position);

        hero = GameObject.FindGameObjectWithTag("Hero").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemyMovement.remainingDistance <= enemyMovement.stoppingDistance)
        {
            target = points[Random.Range(0, points.Count)].position;
            enemyMovement.CalculateDistance(target);
        }  
        else
        {
            enemyMovement.SetDestination(target);
            enemyMovement.CalculateDistance(target);
        }

        timer += Time.deltaTime;
        if (timer > timeToIdle) animator.SetBool("isPatrolling", false);

        float distance = Vector3.Distance(animator.transform.position, hero.position);
        if (distance < enemyMovement.chaseRange) animator.SetBool("isChasing", true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyMovement.SetDestination(enemyMovement.transform.position);
    }

}
