using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;
    public float bulletSpeed = 100f; // The speed of the bullet

    public Camera fpsCam;
    public InputManager inputManager; // Reference to the InputManager

    private float nextTimeToFire = 0f;
    // public Transform enemy; // Reference to the enemy transform
    public GameObject bulletPrefab; // Reference to the bullet prefab

    public ParticleSystem muzzleFlash; // The muzzle flash effect
    public AudioSource shootingSound; // The audio source to play the gunfire sound
    public Transform gunBarrel; // Reference to the gun barrel

    // Update is called once per frame

    void Start()
    {
        shootingSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (inputManager.Fire && Time.time >= nextTimeToFire) // Use the Fire action from the InputManager
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            shootingSound.Play();
        }
    }

    void Shoot()
    {
        // Play the muzzle flash effect
        muzzleFlash.Play();

        // Play the shooting sound
        shootingSound.Play();

        // Create a ray from the center of the screen
        Ray ray = fpsCam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        // Create the bullet
        GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);

        // Get the Rigidbody component of the bullet
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        // If the ray hits something, set the bullet's velocity towards the hit point
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 direction = (hit.point - fpsCam.transform.position).normalized;
            bulletRigidbody.velocity = direction * bulletSpeed;
        }
        // If the ray doesn't hit anything, set the bullet's velocity in the direction of the ray
        else
        {
            bulletRigidbody.velocity = ray.direction * bulletSpeed;
        }
        bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);

        // Get the Rigidbody component of the bullet
        bulletRigidbody = bullet.GetComponent<Rigidbody>();

        // Set the bullet's velocity in the direction of the gun barrel
        bulletRigidbody.velocity = gunBarrel.forward * bulletSpeed;
    }
}