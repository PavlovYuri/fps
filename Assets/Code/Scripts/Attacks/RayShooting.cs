using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RayShooting : MonoBehaviour
{
    public float impactForce = 30.0f;

    public float nextTimeToFire;

    public WeaponCharacter weaponCharacter;
    public Camera camera;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;


    public void Shoot()
    {
        if (weaponCharacter != null)
        {
            muzzleFlash.Play();
            RaycastHit hit;
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, weaponCharacter.range))
            {
                Debug.Log(hit.transform.name);
                ReactiveTarget target = hit.transform.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.TakeDamage(weaponCharacter.damage);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }

                GameObject impactGameObject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGameObject, 0.2f);
            }
        }

    }
}
