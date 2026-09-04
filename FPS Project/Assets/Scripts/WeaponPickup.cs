using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponPrefab; // The weapon to be equipped on pickup
    public float respawnTime = 10.0f; // Time in seconds before respawning

    private bool isPickedUp = false;
    private Collider[] allColliders;
    private Renderer[] allRenderers;
    private SpeenWeapon spinnerScript; // Reference to your other script
    private float trueBaseHeight;   // OG ground height

    void Start()
    {
        trueBaseHeight = transform.position.y;
        spinnerScript = GetComponent<SpeenWeapon>();

        // Find all colliders and renderers on startup
        allColliders = GetComponentsInChildren<Collider>();
        allRenderers = GetComponentsInChildren<Renderer>();

        // Force every single child collider to be a Trigger
        foreach (Collider col in allColliders)
        {
            col.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPickedUp)
        {
            isPickedUp = true;

            // Freeze the spinning and hovering script immediately
            if (spinnerScript != null)
            {
                spinnerScript.isPaused = true;
            }

            Shooter shooter = other.GetComponent<Shooter>();
            if (shooter != null)
            {
                shooter.EquipWeapon(weaponPrefab);
                StartCoroutine(Respawn());
            }
            else
            {
                isPickedUp = false;
                if (spinnerScript != null) spinnerScript.isPaused = false;
            }
        }
    }

    private IEnumerator Respawn()
    {
        // Disable all triggers instantly
        foreach (Collider col in allColliders)
        {
            col.enabled = false;
        }

        // Hide all weapon parts instantly
        foreach (Renderer rend in allRenderers)
        {
            rend.enabled = false;
        }

        yield return new WaitForSeconds(respawnTime);

        // Reset the object physical position back to its true ground center height
        transform.position = new Vector3(transform.position.x, trueBaseHeight, transform.position.z);

        // Sync the cached start position inside SpeenWeapon so the math aligns perfectly
        if (spinnerScript != null)
        {
            spinnerScript.ResetStartPosition(trueBaseHeight);
            spinnerScript.isPaused = false; // Turn the spinning back on
        }

        foreach (Collider col in allColliders)
        {
            col.enabled = true;
        }

        foreach (Renderer rend in allRenderers)
        {
            rend.enabled = true;
        }

        isPickedUp = false;
    }
}