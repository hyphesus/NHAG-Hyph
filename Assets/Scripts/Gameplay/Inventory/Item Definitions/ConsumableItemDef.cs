using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Consumable")]
public class ConsumableItemDef : ItemDef
{
    public StatManager.StatType type;
    public float statValue;
}
