using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
    [SerializeField] private float activeHitTime = 0.5f;
    public Collider specialCollider; // consider adding more colliders and managing them with different hitTimes. Or just attach specific colliders to rigged parts which is supposed to hit
    public ChargeAmount chargeAmount;
    public TempWeaponChecker tempWeaponChecker;
    PlayerLocomotion playerLocomotion;
    Rigidbody playerRb;
    private DamageDealer damageDealer;

    private void Awake()
    {
        specialCollider.enabled = false;
        tempWeaponChecker = GetComponent<TempWeaponChecker>();
        damageDealer = GetComponent<DamageDealer>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerRb = GetComponent<Rigidbody>();
        chargeAmount = GetComponent<ChargeAmount>();
    }
    private void Start()
    {
        GetComponentInChildren<DamageHandler>().damage = GetComponent<StatManager>().GetStat(StatManager.StatType.Attack);
    }
    public void PerformSpecialAttack()
    {
        if (tempWeaponChecker != null && !tempWeaponChecker.tempWeapon && !specialCollider.enabled && chargeAmount.chargeAmount >= 100)
        {
            ActivateSpecialCollider();
            chargeAmount.DecreaseCharge();
            // sfx and animation goes here
        }
    }
    private void ActivateSpecialCollider()
    {
        //TODO make it so player cant move while attacking
        if (specialCollider != null)
        {
            playerRb.velocity = Vector3.zero;
            playerLocomotion.isPunching = true;
            specialCollider.enabled = true;
            StartCoroutine(DeactivateSpecialColliderAfterTime(activeHitTime));
        }
        else
        {
            Debug.LogWarning("Special Collider not assigned!");
        }
    }
    private IEnumerator DeactivateSpecialColliderAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        specialCollider.enabled = false;
        playerLocomotion.isPunching = false;
    }
}

