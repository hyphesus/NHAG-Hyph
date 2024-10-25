using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour
{
    public float speed = 20f; // Speed of the projectile
    public Rigidbody rb;
    [SerializeField] private float projectileLife = 5f;

    private void Start()
    {
        rb.velocity = transform.forward * speed;

        // Destroy the projectile after 5 seconds to prevent it from lingering in the scene
        Destroy(gameObject, projectileLife);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Logic for what happens when the projectile hits something
        }

        Destroy(gameObject);
    }
}
