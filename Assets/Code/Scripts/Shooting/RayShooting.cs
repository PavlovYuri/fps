using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RayShooting : MonoBehaviour
{
    public float impactForce = 30.0f;

    private float nextTimeToFire;

    private Transform weapon;
    private WeaponCharacter weaponCharacter;
    private Transform weaponHolder;
    private Camera camera;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;


    private void Start()
    {
        weapon = transform.parent;
        weaponCharacter = weapon.GetComponent<WeaponCharacter>();
        weaponHolder = weapon.parent;
        camera = weaponHolder.transform.parent.GetComponent<Camera>();
        Light pointLight = muzzleFlash.GetComponentInChildren<Light>();
        muzzleFlash.Stop();
        pointLight.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + weaponCharacter.fireRate;
            Shoot();
        }
    }

    void Shoot()
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
