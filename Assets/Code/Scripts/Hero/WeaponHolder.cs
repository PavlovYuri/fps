using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public int weaponIndicator;
    public GameObject[] weapons = new GameObject[2];
    private WeaponCharacter weaponCharacter;
    public int weaponIndex = 0;
    void Start()
    {
        SwitchWeapon(weaponIndex);
    }

    void Update()
    {
        if (Input.mouseScrollDelta.y > 0 && weaponIndex < weapons.Length-1)
        {
            weaponIndex++;
            SwitchWeapon(weaponIndex);
        }
        else if (Input.mouseScrollDelta.y < 0 && weaponIndex > 0)
        {
            weaponIndex--;
            SwitchWeapon(weaponIndex);
        }
    }

    public void SwitchWeapon(int index)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }

        weapons[index].SetActive(true);
        weaponCharacter = weapons[index].GetComponent<WeaponCharacter>();
        if (weaponCharacter._isFirearms)
        {
            weapons[index].transform.Find("ShotPoint").GetComponent<RayShooting>().muzzleFlash.Stop();
        }
    }
}
