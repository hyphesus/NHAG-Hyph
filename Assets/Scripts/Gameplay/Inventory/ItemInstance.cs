using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstance : MonoBehaviour
{
    [SerializeField] ConsumableItemDef consumableItemDef;
    [SerializeField] bool isPermanent;

    private void Start()
    {
        //Instantiate(consumableItemDef.item, this.transform.position, Quaternion.identity, this.gameObject.transform);
    }
    private void OnCollisionEnter(Collision collision)
    {
        InventoryManager inv = collision.gameObject.GetComponent<InventoryManager>();
        if (inv != null)
        {
            if(consumableItemDef.GetType() == typeof(ConsumableItemDef))
            {
                inv.EquipConsumable(consumableItemDef.type, consumableItemDef.statValue, isPermanent);
                Destroy(this.gameObject);
            }
        }
    }
}
