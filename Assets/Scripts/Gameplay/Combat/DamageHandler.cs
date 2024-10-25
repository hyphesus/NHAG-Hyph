using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    [HideInInspector] public float damage;

    public float GetDamageValue()
    {
        return damage;
    }
}