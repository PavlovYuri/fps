using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Take : MonoBehaviour
{
    public float distance = 5.0f;
    public Transform pos;
    public InventoryManager inventoryManager;
    public Camera camera;
    public WeaponHolder weaponHolder;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit; 
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
            {
                if (hit.collider.GetComponent<Item>())
                {
                    Item item = hit.collider.GetComponent<Item>();
                    switch (item.itemClass)
                    {
                        case "weapon":
                            PutInCell(inventoryManager.weapons, item, inventoryManager.weaponPanel);
                            break;
                        case "shell":
                            PutInCell(inventoryManager.shells, item, inventoryManager.shellPanel);
                            break;
                        case "other":
                            PutInCell(inventoryManager.others, item, inventoryManager.otherPanel);
                            break;
                        default:
                            break;

                    }
                    
          
                }
            }
        }
    }
    void PutInCell(List<Item> items, Item item, GameObject panel)
    {
        for (int i = 0; i < items.Count; i++)
        {

            if (items[i].id == item.id && item._isStackable == true)
            {
                items[i] = item;
                Transform cell = panel.transform.GetChild(i);
                Transform icon = cell.GetChild(0);
                TextMeshProUGUI numberItemsText = icon.GetChild(0).GetComponent<TextMeshProUGUI>();
                numberItemsText.enabled = true;
                numberItemsText.text = (int.Parse(numberItemsText.text) + 1).ToString();
            }

            else if (items[i].id == 0)
            {
                items[i] = item;

            } 
            if (item.itemClass == "weapon")
            {
                GameObject weapon = Instantiate(Resources.Load(item.prefabPath, typeof(GameObject))) as GameObject;
                
                weaponHolder.weapons.Add(weapon);
                weapon.transform.SetParent(weaponHolder.transform, false);
                weapon.transform.localPosition = new Vector3(item.xHandPosition, item.yHandPosition, item.zHandPosition);
                weapon.transform.localRotation = Quaternion.Euler(item.xHandRotation, item.yHandRotation, item.zHandRotation);

                if (weapon.GetComponent<WeaponCharacter>()._isFirearms)
                {
                    Transform shotPoint = weapon.transform.Find("ShotPoint");
                    RayShooting rayShooting = shotPoint.GetComponent<RayShooting>();
                    Transform weaponHolder = weapon.transform.parent;
                    rayShooting.camera = weaponHolder.transform.parent.GetComponent<Camera>();
                }
            }
            Destroy(item.gameObject);
            break;
        }
    }

}
