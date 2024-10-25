using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour
{
    public Collider meleeCollider;// consider adding more colliders and managing them with different hitTimes. Or just attach specific colliders to rigged parts which is supposed to hit
    public TempWeaponChecker tempWeaponChecker;
    [SerializeField] private float activeHitTime = 0.1f;
    PlayerLocomotion playerLocomotion;
    Rigidbody playerRb;
    InputManager inputManager;

    private DamageDealer damageDealer;

    private void Awake()
    {
        meleeCollider.enabled = false;
        meleeCollider.gameObject.GetComponent<MeshRenderer>().enabled = false;
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
    public void PerformMeleeAttack()
    {
        if (tempWeaponChecker != null && !tempWeaponChecker.tempWeapon && !meleeCollider.enabled)
        {
            ActivateMeleeCollider();

            // sfx and animation goes here
            // animation logic changes goes here
            //AudioHelper.PlayOneShotWithParameters("event:/GabrielLightHit1", this.transform.position, ("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"))); //TEMP Play Gabe L1

        }
    }

    private void ActivateMeleeCollider()
    {
        //TODO make it so player cant move while attacking

        if (meleeCollider != null)
        {
            inputManager.lightInput = true;
            StartCoroutine(inputManager.SwitchLightBool());
            playerRb.velocity = Vector3.zero;
            playerLocomotion.isPunching = true;
            meleeCollider.enabled = true;
            meleeCollider.gameObject.GetComponent<MeshRenderer>().enabled = true;
            StartCoroutine(DeactivateMeleeColliderAfterTime(activeHitTime));
        }
        else
        {
            Debug.LogWarning("Melee Collider not assigned!");
        }
    }

    private IEnumerator DeactivateMeleeColliderAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        meleeCollider.enabled = false;
        meleeCollider.gameObject.GetComponent<MeshRenderer>().enabled = false;
        playerLocomotion.isPunching = false;
    }
}