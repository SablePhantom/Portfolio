using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 40.0f;
    public float accuracySpread = 0.1f;
    public int pelletCount = 3;

    private void Start()
    {
        cam = Camera.main;
    }

    public override void ShootBullet()
    {
        for (int i = 0; i < pelletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, cam.transform.position + cam.transform.forward, Quaternion.identity);
            bullet.layer = LayerMask.NameToLayer("Bullet"); // Set the bullet layer to "Bullet"
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                Vector3 spread = new Vector3(Random.Range(-accuracySpread, accuracySpread), Random.Range(-accuracySpread, accuracySpread), 0);
                Vector3 shootingDirection = (cam.transform.forward + spread).normalized;
                bulletRb.velocity = shootingDirection * bulletSpeed;
            }
            Destroy(bullet, 5.0f); // Destroy bullet after 5 seconds
        }
    }
}