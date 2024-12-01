using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public GameObject projectilePrefab; // The projectile prefab to instantiate
    public Transform firePoint; // The point from where the projectile will be fired

    public void PerformRangedAttack()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            Debug.LogWarning("ProjectilePrefab or FirePoint is not assigned.");
        }
    }
}
