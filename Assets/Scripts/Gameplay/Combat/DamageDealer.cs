using UnityEngine;
using System.Collections;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float collisionCooldown = 0.1f;
    private bool canDealDamage = true;
    private DamageHandler damageHandler;

    private void Awake()
    {
        damageHandler = GetComponent<DamageHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canDealDamage && other.CompareTag("Enemy"))
            DealEnemyDamage(other.gameObject);
        if (canDealDamage && other.CompareTag("Table"))
            DealTableDamage(other.gameObject);
    }

    private void DealEnemyDamage(GameObject target)
    {
        EnemyBehavior enemyBehavior = target.GetComponent<EnemyBehavior>();

        if (enemyBehavior != null)
        {
            enemyBehavior.GotHit(damageHandler.GetDamageValue());
            StartCoroutine(CollisionCooldown());
        }
        else
        {
            Debug.LogWarning("No EnemyBehavior found");
        }
    }
    void DealTableDamage(GameObject target)
    {
        TableScript tableScript = target.GetComponent<TableScript>();

        if (tableScript != null)
        {
            tableScript.GetHit(damageHandler.GetDamageValue());
            StartCoroutine(CollisionCooldown());
        }
        else
            Debug.LogError("No TableScript found");
    }
    private IEnumerator CollisionCooldown()
    {
        canDealDamage = false;
        yield return new WaitForSeconds(collisionCooldown);
        canDealDamage = true;
    }
}