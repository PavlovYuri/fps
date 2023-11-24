using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 5.0f;
    public float fireballSpeed = 5.0f;
    public float obstacleRange = 5.0f;
    public bool _alive = true;
    public int health = 100;

    [SerializeField]
    private GameObject[] fireballsPrefab;
    private GameObject fireball;

    private void Start()
    {
        _alive = true;
    }

    private void Update()
    {
       if (_alive)
       {
            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward); 
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;

                if (hitObject.GetComponent<CharacterController>())
                {
                    if (fireball == null)
                    {
                        int randFireball = Random.Range(0, fireballsPrefab.Length);
                        fireball = Instantiate(fireballsPrefab[randFireball]);
                        fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRange)
                {
                    float angleRotation = Random.Range(-100, 100);
                    transform.Rotate(0, angleRotation, 0); 
                }
            }
       }
    }
    public void ReactToHit(int damage)
    {
        this.health -= damage;
    }
}
