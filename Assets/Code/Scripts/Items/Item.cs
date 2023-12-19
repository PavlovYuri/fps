using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string nameItem;
    public int id;
    public int countItem;
    public bool _isStackable;

    public float xHandPosition;
    public float yHandPosition;
    public float zHandPosition;
    public float xHandRotation;
    public float yHandRotation;
    public float zHandRotation;

    [Multiline(5)]
    public string descriptionItem;
    public string iconPath;
    public string prefabPath;
    public string itemClass;
}
