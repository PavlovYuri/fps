using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 20.0f;
    public int damage = 10;

    private void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionObject = collision.gameObject;
        HeroCharacter character = collisionObject.GetComponent<HeroCharacter>();
        if (character != null)
        {
            character.Hurt(damage);
        }
        Destroy(gameObject);
    }
}
