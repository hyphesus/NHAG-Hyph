using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class ItemDef : ScriptableObject
{
    public string itemName;
    public GameObject item;
}
