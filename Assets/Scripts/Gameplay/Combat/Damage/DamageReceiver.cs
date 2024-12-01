using UnityEngine;
using System.Collections;

public class DamageReceiver : MonoBehaviour
{
    [SerializeField] private float collisionCooldown = 0.5f;
    private bool canReceiveDamage = true;
    private DamageHandler damageHandler;

    private void Awake()
    {
        damageHandler = GetComponent<DamageHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canReceiveDamage)
        {
            if (other.CompareTag("Player1") || other.CompareTag("Player2"))
            {
                ReceiveDamage(other.gameObject);

            }
        }
    }

    private void ReceiveDamage(GameObject target)
    {
        target.GetComponent<StatManager>().LowerStat(StatManager.StatType.Health, damageHandler.GetDamageValue());
        Debug.Log("Damage dealt: " + damageHandler.GetDamageValue());

        //AudioHelper.PlayOneShotWithParameters("event:/GabrielTookDMG", this.transform.position, ("SFXVolume", PlayerPrefs.GetFloat("SFXVolume")));

        StartCoroutine(CollisionCooldown());
    }

    private IEnumerator CollisionCooldown()
    {
        canReceiveDamage = false;
        yield return new WaitForSeconds(collisionCooldown);
        canReceiveDamage = true;
    }
}