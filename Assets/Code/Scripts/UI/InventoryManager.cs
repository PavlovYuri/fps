using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;

public class InventoryManager : MonoBehaviour
{
    public List<Item> weapons;
    public List<Item> shells;
    public List<Item> others;
    public GameObject crosshair;
    public GameObject inventoryPanel;
    public GameObject weaponPanel;
    public GameObject shellPanel;
    public GameObject otherPanel;
    void Start()
    {
        InitializeInventoryPart(weapons, weaponPanel.transform.childCount);
        InitializeInventoryPart(shells, shellPanel.transform.childCount);
        InitializeInventoryPart(others, otherPanel.transform.childCount);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            crosshair.SetActive(!crosshair.activeSelf);
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            DisplayItems(weapons, weaponPanel);
            DisplayItems(shells, shellPanel);
            DisplayItems(others, otherPanel);
        }
    }

    void InitializeInventoryPart(List<Item> items, int itemCount)
    {
        for (int i = 0; i < itemCount; i ++)
        {
            Item item = new Item();
            item.id = 0;
            items.Add(item);
        }
    }

    void DisplayItems(List<Item> items, GameObject panel)
    {
        for (int i  = 0; i < items.Count; i++)
        {
            if (items[i].id != 0)
            {
                Transform cell = panel.transform.GetChild(i);
                Transform icon = cell.GetChild(0);

                if (items[i].iconPath != null)
                {
                    UnityEngine.UI.Image img = icon.GetComponent<UnityEngine.UI.Image>();
                    img.sprite = Resources.Load<Sprite>(items[i].iconPath);
                }
            }
        }
    }
}
