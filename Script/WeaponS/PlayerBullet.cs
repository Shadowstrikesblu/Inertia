using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;
        if (hitTransform.CompareTag("Enemy"))
        {
            Debug.Log("AMBOUT TO HIT ENEMY");
            hitTransform.GetComponent<EnemyHealth>().TakeDamage(10);
            Destroy(gameObject);

        }
    }
}
