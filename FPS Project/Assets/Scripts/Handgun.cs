using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : Weapon
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 40.0f;
    public float accuracySpread = 0.05f;

    public override void ShootBullet()
    {
        if (cam == null)
        {
            Debug.LogError("Camera reference not assigned in Handgun!");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, cam.transform.position + cam.transform.forward, Quaternion.identity);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            Vector3 spread = new Vector3(Random.Range(-accuracySpread, accuracySpread), Random.Range(-accuracySpread, accuracySpread), 0);
            Vector3 shootingDirection = (cam.transform.forward + spread).normalized;
            bulletRb.velocity = shootingDirection * bulletSpeed;
        }
        Destroy(bullet, 5.0f);
    }
}
