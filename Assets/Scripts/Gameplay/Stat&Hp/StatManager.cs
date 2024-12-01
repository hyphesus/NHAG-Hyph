using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public enum StatType
    {
        Null = 0,
        Health = 1,
        Attack = 2,
        Speed = 3,
    }
    [Serializable]
    public class Stat
    {
        public StatType type;
        public float value;
    }
    [SerializeField] public List<Stat> statList = new List<Stat>();
    public delegate void StatUpdateFunction(StatType aType, float aNewValue);
    Dictionary<StatType, StatUpdateFunction> dictionaryOfCallbacks = new Dictionary<StatType, StatUpdateFunction>();

    public void LowerStat(StatType aType, float aValue)
    {
        foreach (Stat stat in statList)
        {
            if (stat.type == aType)
            {
                float old = stat.value;
                stat.value -= aValue;
                if (dictionaryOfCallbacks.ContainsKey(aType) == false)
                    return;
                dictionaryOfCallbacks[aType].Invoke(aType, stat.value);
            }
        }
    }
    public void RaiseStat(StatType aType, float aValue)
    {
        foreach (Stat stat in statList)
        {
            if (stat.type == aType)
            {
                float old = stat.value;
                stat.value += aValue;
                if (dictionaryOfCallbacks.ContainsKey(aType) == false)
                {
                    return;
                }
                dictionaryOfCallbacks[aType].Invoke(aType, stat.value);
            }
        }
    }
    public float GetStat(StatType aType)
    {
        foreach (var item in statList)
        {
            if (item.type == aType)
                return item.value;
        }
        Debug.LogError(aType + " does not exist in " + gameObject.name + "'s statSystem");
        return float.MinValue;
    }
    public void AddCallBack(StatType aType, StatUpdateFunction aFunc)
    {
        if (dictionaryOfCallbacks.ContainsKey(aType))
            dictionaryOfCallbacks[aType] += aFunc;
        else
            dictionaryOfCallbacks[aType] = aFunc;
    }
}
