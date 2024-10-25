using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //figure out a way to make it adjustable in the editor later
    //[SerializeField] 
    [HideInInspector] public string currentItem = null;
    [HideInInspector] public bool hasItem = false;
    private void OnTriggerEnter(Collider other)
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "QuestItem")
        {
            //pickup item
            if (hasItem)
            {
                Debug.Log("you already have a quest item");
                return;
            }
            currentItem = collision.gameObject.GetComponent<QuestItemScript>().ItemName;
            hasItem = true;
            Destroy(collision.gameObject);
        }
    }
    public void EmptyQuestInventory()
    {
        currentItem = null;
        hasItem = false;
    }


    public void EquipConsumable(StatManager.StatType type, float value, bool isPermanent)
    {
        if (isPermanent)
        {
            IncreaseStatPermanent(type, value);
        }
    }
    void IncreaseStatPermanent(StatManager.StatType type, float value)
    {
        GetComponent<StatManager>().RaiseStat(type, value);
        Debug.Log("stat raised");
    }
    IEnumerator IncreaseStatTemp()
    {
        return null;
    }
}
