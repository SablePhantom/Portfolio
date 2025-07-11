using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponPrefab; // The weapon to be equipped on pickup
    public float respawnTime = 10.0f; // Time in seconds before respawning

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player collides with the sphere
        {
            Shooter shooter = other.GetComponent<Shooter>();
            if (shooter != null)
            {
                shooter.EquipWeapon(weaponPrefab); // Equip the weapon
                StartCoroutine(Respawn()); // Start respawn coroutine
            }
        }
    }

    private IEnumerator Respawn()
    {
        // Disable the sphere and make sure it doesn't collide
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }

        yield return new WaitForSeconds(respawnTime); // Wait for respawn time

        // Reactivate the sphere
        if (collider != null)
        {
            collider.enabled = true;
        }

        if (renderer != null)
        {
            renderer.enabled = true;
        }
    }
}