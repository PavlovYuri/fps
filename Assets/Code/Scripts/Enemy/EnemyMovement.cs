using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float rotationSpeed = 7.0f;

    public float chaseRange = 20.0f;
    public float attackRange = 10.0f;

    public float degreeStep = 45.0f;
    public float eyeHeight = 4.0f;

    public float remainingDistance;
    public float stoppingDistance;

    public GameObject enemyPoints;

    public void CalculateDistance(Vector3 target)
    {
        Vector3 pointRadius = new Vector3(target.x + 1.0f, target.y, target.z + 1.0f);
        stoppingDistance = Vector3.Distance(target, pointRadius);
        remainingDistance = Vector3.Distance(transform.position, target);
    }
    public void SetDestination(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        Vector3 eyeLevelTarget = new Vector3(target.x, eyeHeight, target.z);
        Vector3 direction = (eyeLevelTarget - transform.position).normalized;

        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * degreeStep * Time.deltaTime);
        }
    }

}
