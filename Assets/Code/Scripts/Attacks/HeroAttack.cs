using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : SoundManager
{
    public WeaponHolder weaponHolder;
    public ColdWeaponAttack coldWeaponAttack;
    Transform currentWeapon;

    void Update()
    {
        foreach (Transform weapon in weaponHolder.transform)
        {
            if (weapon.gameObject.activeSelf)
            {
                currentWeapon = weapon; 
            }
        }

        if (!currentWeapon.GetComponent<WeaponCharacter>()._isFirearms)
        {
            if (Input.GetMouseButton(0))
            {
                coldWeaponAttack.ColdAttack(); 
            }
        } 
        else
        {
            Transform shotPoint = currentWeapon.Find("ShotPoint");
            RayShooting rayShooting = shotPoint.GetComponent<RayShooting>();
            WeaponCharacter weaponCharacter = currentWeapon.GetComponent<WeaponCharacter>();
            if (Input.GetMouseButton(0) && Time.time >= rayShooting.nextTimeToFire)
            {
                rayShooting.nextTimeToFire = Time.time + weaponCharacter.fireRate;
                //PlaySounds(sounds[0]);
                rayShooting.Shoot();
                
            }
        }

    }
}
