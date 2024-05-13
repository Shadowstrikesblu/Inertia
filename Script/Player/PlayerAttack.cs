using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // You can adjust this value in the Unity editor to control the strength of the attack
    public float weaponDistance = 10f;

    [Header("Player Settings")]
    public float attackStrength = 10f;
    public PlayerInput.OnFootActions onFoot;
    public PlayerAttack attack;

    public Animator animator;
    [Header("Weapon Value")]
    public Transform gunBarrel;
    void Update()
    {

    }
    public void AttackDistance()
    {
        // Implement your attack logic here
        // For example, you could instantiate a projectile and apply a force to it

        // Instantiate the projectile at the player's position
        // Transform gunbarrel = attack.gunBarrel;
        // GameObject projectile = GameObject.Instantiate(Resources.Load("Prefabs/Bullet"), gunbarrel.position, gunbarrel.rotation) as GameObject;

        // // Apply a force to the projectile
        // Rigidbody rb = projectile.GetComponent<Rigidbody>();
        // rb?.AddForce(transform.forward * attackStrength, ForceMode.Impulse);
        Debug.Log("BAM");
    }
    public void AttackMelee()
    {
        // Define the maximum distance of the attack


    }
}