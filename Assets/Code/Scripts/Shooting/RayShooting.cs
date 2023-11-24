using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooting : MonoBehaviour
{
    public int damage = 20;
    public float range = 100.0f;
    public float impactForce = 30.0f;
    public float fireRate = 0.5f;

    private float nextTimeToFire;

    private Transform weapon;
    private Camera camera;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;


    private void Start()
    {
        weapon = transform.parent;
        camera = weapon.transform.parent.GetComponent<Camera>();
        Light pointLight = muzzleFlash.GetComponentInChildren<Light>();
        pointLight.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            ReactiveTarget target = hit.transform.GetComponent<ReactiveTarget>();
            if (target != null)
            {
                target.TakeDamage(damage); 
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
