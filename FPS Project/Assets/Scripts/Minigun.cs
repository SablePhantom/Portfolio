using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : Weapon
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 90.0f;
    public float accuracySpread = 0.1f;

    [Header("Minigun Timing")]
    public float maxFireRate = 0.03f;   // Blazing fast fire rate when fully spooled
    public float windUpTime = 1.5f;     // Time in seconds to spin up before shooting

    private bool isFiring = false;
    private float currentWindUp = 0f;   // Track current spool progress
    private float nextFireTime = 0f;

    [Header("Visuals (Optional)")]
    public Transform rotatingBarrels;
    public float maxBarrelSpinSpeed = 1000f;

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
        // Keep running as long as the trigger is held OR the barrels are still slowing down
        while (Input.GetMouseButton(0) || currentWindUp > 0f)
        {
            if (Input.GetMouseButton(0))
            {
                // Spool UP
                currentWindUp += Time.deltaTime;
                if (currentWindUp > windUpTime)
                {
                    currentWindUp = windUpTime;
                }
            }
            else
            {
                // Spool DOWN if trigger released
                currentWindUp -= Time.deltaTime;
                if (currentWindUp < 0f)
                {
                    currentWindUp = 0f;
                }
            }

            // Handle visual barrel spinning based on spool progress
            if (rotatingBarrels != null)
            {
                float currentSpin = (currentWindUp / windUpTime) * maxBarrelSpinSpeed;
                rotatingBarrels.Rotate(0, 0, currentSpin * Time.deltaTime, Space.Self);
            }

            // SHOOTING TIME: Only fire if fully spooled up and cooldown has passed
            if (Input.GetMouseButton(0) && currentWindUp >= windUpTime && Time.time >= nextFireTime)
            {
                nextFireTime = Time.time + maxFireRate;

                // Instantiate and launch the bullet safely inside one block
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

            yield return null; // Wait for the next frame
        }

        isFiring = false;
    }

}