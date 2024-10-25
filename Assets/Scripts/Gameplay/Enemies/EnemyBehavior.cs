using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    Rigidbody enemyRB;
    //temporary reference to "player" position
    [HideInInspector] public GameObject player1;
    [HideInInspector] public GameObject player2;
    //[SerializeField] GameObject player;
    [HideInInspector] public bool isHit = false;
    [HideInInspector] public EnemySpawner enemySpawner;
    int knockbackModifier = 0;
    int comboTracker = 0;
    bool pushed = false;
    float cooldownTimer;
    StatManager statManager;
    float damageToDeal = 0;
    private void Awake()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        enemyRB = GetComponent<Rigidbody>();
        //Debug.Log("Press 'E' to punch your enemy");
        statManager = GetComponent<StatManager>();
    }
    public void GotHit(float incomingDamage)//(Vector3 attackerPos)
    {
        //each time you hit an enemy while they're staggered, the knockback will increase
        //TODO: when multiplayer gets introduced, have it so if the enemy is hit by the second player, the cooldown resets but the knockback multiplier isnt
        if (knockbackModifier >= 3 || pushed == true)
        {
            return;
        }
        damageToDeal += incomingDamage;
        Debug.Log("PUNCH!!!");
        isHit = true;
        comboTracker++;
        knockbackModifier++;

        //AudioHelper.PlayOneShotWithParameters("event:/EnemyHit1", this.transform.position, ("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"))); //play impact sound
        
        StartCoroutine(StaggerCooldown());
    }
    IEnumerator StaggerCooldown()
    {
        //small recovery time after the enemy gets hit
        yield return new WaitForSeconds(0.9f);
        comboTracker--;
        pushed = true;
        PushBack();
    }
    void PushBack()
    {
        if (comboTracker > 0)
        {
            return;
        }
        //Get the Vector3 difference between enemy and player position
        //TODO push back from player 1 for now until TODO listed above is fixed
        Vector3 tempDirection = transform.position - player1.transform.position;
        tempDirection.Normalize();
        tempDirection.y = 1;
        //push the enemy in the oposite direction
        enemyRB.AddForce(tempDirection * ((2 * enemyRB.mass) + (knockbackModifier * enemyRB.mass)), ForceMode.Impulse);
        StartCoroutine(HitCooldown());
    }
    IEnumerator HitCooldown()
    {
        switch (knockbackModifier)
        {
            case 1:
                cooldownTimer = 0.5f;
                break;
            case 2:
                cooldownTimer = 0.6f;
                break;
            case 3:
                cooldownTimer = 0.75f;
                break;
            default:
                cooldownTimer = 0;
                break;
        }
        //small recovery time after the enemy gets hit
        yield return new WaitForSeconds(cooldownTimer);
        isHit = false;
        knockbackModifier = 0;
        comboTracker = 0;
        pushed = false;
        statManager.LowerStat(StatManager.StatType.Health, damageToDeal);
        Debug.Log("Damage dealt: " + damageToDeal);
        damageToDeal = 0;
    }
    public void SetEnemySpawner(EnemySpawner tempEnemySpawner)
    {
        enemySpawner = tempEnemySpawner;
    }
    //TODO make enemy despawning logic consistent
    public void Die()
    {
        if (enemySpawner != null)
        {
            enemySpawner.cameraLockManager.EnemySlain();
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("somehow there is no reference to the spawner");
        }
    }
}
