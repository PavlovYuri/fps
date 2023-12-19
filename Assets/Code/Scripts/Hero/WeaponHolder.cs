using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public int weaponIndicator;
    public List<GameObject> weapons = new List<GameObject>();
    public KeyCode[] hotKeys = new KeyCode[2];
    private WeaponCharacter weaponCharacter;
    public int weaponIndex = 0;
    void Start()
    {
        SwitchWeapon(weaponIndex);
    }

    void Update()
    {
        if (Input.mouseScrollDelta.y > 0 && weaponIndex < weapons.Count-1)
        {
            weaponIndex++;
            SwitchWeapon(weaponIndex);
        }
        else if (Input.mouseScrollDelta.y < 0 && weaponIndex > 0)
        {
            weaponIndex--;
            SwitchWeapon(weaponIndex);
        }
        for (int i = 0; i < 5; i++)
        {
            if (Input.GetKeyDown(hotKeys[i]))
            {
                SwitchWeapon(i);
            }
        }
    }

    public void SwitchWeapon(int index)
    {
        if (weapons[index] != null)
        {
            for (int i = 0; i < weapons.Count; i++)
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
}
