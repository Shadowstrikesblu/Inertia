using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipWeapon : MonoBehaviour
{
    public Transform weaponSocket;

    // Reference to the weapon prefab
    public GameObject weaponPrefab;

    // Distance from the player's root bone to the weapon

    public float weaponDistance = 10f;
    public float attackStrength = 10f;

    public void EquipWeapon()
    {
        // Calculate the weapon's position
        Vector3 weaponPosition = transform.position + transform.forward * weaponDistance;

        // Instantiate the weapon at the calculated position and the player's rotation
        GameObject weapon = Instantiate(weaponPrefab, weaponPosition, transform.rotation);

        // Set the weapon's parent to the weapon socket
        weapon.transform.SetParent(weaponSocket);
    }
}
