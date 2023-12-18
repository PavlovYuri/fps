using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string nameItem;
    public int id;
    public int countItem;
    public bool _isStackable;

    [Multiline(5)]
    public string descriptionItem;
    public string iconPath;
    public string prefabPath;
    public string itemClass;
}
