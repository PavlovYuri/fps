using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class PatrolBehaviour : StateMachineBehaviour
{
    float timer;
    float timeToIdle = 10.0f;
    NavMeshAgent agent;
    List<Transform> points = new List<Transform>();

    Transform hero;
    float chaseRange = 10.0f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        Transform pointsObject = GameObject.FindGameObjectWithTag("EnemyPoints").transform;
        foreach (Transform t in pointsObject) 
        {
            points.Add(t);
        }

        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(points[0].position);

        hero = GameObject.FindGameObjectWithTag("Hero").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Debug.Log("Go to patrol!");
            agent.SetDestination(points[Random.Range(0, points.Count)].position);
        }        

        timer += Time.deltaTime;
        if (timer > timeToIdle) animator.SetBool("isPatrolling", false);

        float distance = Vector3.Distance(animator.transform.position, hero.position);
        if (distance < chaseRange) animator.SetBool("isChasing", true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

}
