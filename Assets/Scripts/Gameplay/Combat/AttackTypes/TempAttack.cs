using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempAttack : MonoBehaviour
{
    [SerializeField] private float activeHitTime = 0.1f;
    public Collider tempWeaponCollider;
    public TempWeaponChecker tempWeaponChecker;
    PlayerLocomotion playerLocomotion;
    Rigidbody playerRb;
    private DamageDealer damageDealer;
    InputManager inputManager;

    private void Awake()
    {
        tempWeaponCollider.enabled = false;
        tempWeaponChecker = GetComponent<TempWeaponChecker>();
        damageDealer = GetComponent<DamageDealer>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerRb = GetComponent<Rigidbody>();
        inputManager = GetComponent<InputManager>();
    }
    private void Start()
    {
        GetComponentInChildren<DamageHandler>().damage = GetComponent<StatManager>().GetStat(StatManager.StatType.Attack);
    }
    public void PerformTempAttack()
    {
        if (tempWeaponChecker != null && tempWeaponChecker.tempWeapon && !tempWeaponCollider.enabled)
        {
            ActivateTempWeaponCollider();
            // sfx and animation goes here
        }

    }
    public void PerformHeavyTempAttack()
    {
        if (tempWeaponChecker != null && !tempWeaponChecker.tempWeapon && !tempWeaponCollider.enabled)
        {
            ActivateTempWeaponHeavyCollider();
            // sfx and animation goes here
            // animation logic changes goes here
        }
    }
    private void ActivateTempWeaponCollider()
    {
        //TODO make it so player cant move while attacking

        if (tempWeaponCollider != null)
        {
            activeHitTime = 0.1f;
            inputManager.lightInput = true;
            StartCoroutine(inputManager.SwitchLightBool());
            playerRb.velocity = Vector3.zero;
            playerLocomotion.isPunching = true;
            tempWeaponCollider.enabled = true;
            tempWeaponCollider.gameObject.GetComponent<MeshRenderer>().enabled = true;
            StartCoroutine(DeactivateTempWeaponColliderAfterTime(activeHitTime));
        }
        else
        {
            Debug.LogWarning("Temporary Weapon Collider not assigned!");
        }
    }

    private void ActivateTempWeaponHeavyCollider()
    {
        //TODO make it so player cant move while attacking

        if (tempWeaponCollider != null)
        {
            activeHitTime = 0.3f;
            inputManager.heavyInput = true;
            StartCoroutine(inputManager.SwitchLightBool());
            playerRb.velocity = Vector3.zero;
            playerLocomotion.isPunching = true;
            tempWeaponCollider.enabled = true;
            tempWeaponCollider.gameObject.GetComponent<MeshRenderer>().enabled = true;
            StartCoroutine(DeactivateTempWeaponColliderAfterTime(activeHitTime));
        }
        else
        {
            Debug.LogWarning("Temporary Weapon Collider not assigned!");
        }
    }

    private IEnumerator DeactivateTempWeaponColliderAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        tempWeaponCollider.enabled = false;
        tempWeaponCollider.gameObject.GetComponent<MeshRenderer>().enabled = false;
        playerLocomotion.isPunching = false;
    }
}
