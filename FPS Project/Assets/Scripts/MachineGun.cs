using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapon
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 50.0f;
    public float accuracySpread = 0.05f;
    public float fireRate = 0.1f;
    private bool isFiring = false;

    public override void ShootBullet()
    {
        if (!isFiring)
        {
            isFiring = true;
            StartCoroutine(FireRoutine());
        }
    }

    private IEnumerator FireRoutine()
    {
        while (Input.GetMouseButton(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, cam.transform.position + cam.transform.forward, Quaternion.identity);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                Vector3 spread = new Vector3(Random.Range(-accuracySpread, accuracySpread), Random.Range(-accuracySpread, accuracySpread), 0);
                Vector3 shootingDirection = (cam.transform.forward + spread).normalized;
                bulletRb.velocity = shootingDirection * bulletSpeed;
            }
            Destroy(bullet, 5.0f);
            yield return new WaitForSeconds(fireRate);
        }
        isFiring = false;
    }
}