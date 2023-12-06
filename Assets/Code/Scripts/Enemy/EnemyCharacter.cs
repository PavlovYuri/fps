using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCharacter : MonoBehaviour
{
    public float fireballSpeed = 5.0f;
    public float obstacleRange = 5.0f;
    public bool _alive = true;
    public int health = 100;

    [SerializeField]
    private GameObject[] fireballsPrefab;
    private GameObject fireball;
    void Start()
    {
        _alive = true;
    }

    void Update()
    {
        
    }

    public void Attack()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            if (hitObject.GetComponent<CharacterController>())
            {

                int randFireball = Random.Range(0, fireballsPrefab.Length);
                fireball = Instantiate(fireballsPrefab[randFireball]);
                fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                //fireball.transform.rotation = transform.rotation;

            }
        }
    }
    public void ReactToHit(int damage)
    {
        this.health -= damage;
        Debug.Log(this.health);
    }
}
