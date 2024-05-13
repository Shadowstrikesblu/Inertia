using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float health = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount; // Decrease the health by the damage amount

        // If the health is less than or equal to 0
        if (health <= 0f)
        {
            Die(); // Call the Die method
        }
    }

    void Die()
    {
        Destroy(gameObject); // Destroy the enemy
    }
}
