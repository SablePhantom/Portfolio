using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shooter : MonoBehaviour
{
    private Camera cam;
    public GameObject particleSysPrefab;
    public GameObject grenadePrefab;
    public GameObject defaultWeaponPrefab;
    public float maxGrenadeImpulse = 10.0f;
    public float chargeTime = 2.0f;
    private float grenadeImpulse = 5.0f;
    public bool isCharging = false;
    private float chargeStartTime;
    public Weapon currentWeapon;

    private IEnumerator GeneratePS(RaycastHit hit)
    {
        GameObject ps = Instantiate(particleSysPrefab, hit.point, Quaternion.LookRotation(hit.normal));
        yield return new WaitForSeconds(1);
        Destroy(ps);
    }

    void Start()
    {
        // Look specifically for the gameplay camera
        GameObject mainCamObj = GameObject.FindWithTag("MainCamera");

        if (mainCamObj != null)
        {
            cam = mainCamObj.GetComponent<Camera>();
        }

        // Lock the cursor ONLY now that gameplay has actually started
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (cam == null)
        {
            Debug.LogError("Gameplay Main Camera not found! If loading additively, ensure the MainCamera is active in Scene 1.");
            return;
        }

        // Initialize the weapon if it's assigned
        if (currentWeapon != null && currentWeapon.gameObject.scene.name == null)
        {
            currentWeapon = null;
        }

        // This will safely spawn a clone of your weapon in the game world
        if (defaultWeaponPrefab != null)
        {
            EquipWeapon(defaultWeaponPrefab);
        }
    }

    void OnGUI()
    {
        int size = 12;
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "+");
    }

    void Update()
    {
        // If the game is paused, ignore shooting and throwing inputs entirely
        if (Time.timeScale == 0f) return;

        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) return;

        if (Input.GetMouseButtonDown(0) && currentWeapon != null)
        {
            currentWeapon.ShootBullet();
        }

        if (Input.GetMouseButtonDown(1))
        {
            isCharging = true;
            chargeStartTime = Time.time;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isCharging = false;
            ThrowGrenade();
        }
    }

    private void ThrowGrenade()
    {
        float chargeDuration = Time.time - chargeStartTime;
        float finalImpulse = Mathf.Clamp(chargeDuration / chargeTime * maxGrenadeImpulse, grenadeImpulse, maxGrenadeImpulse);

        GameObject grenade = Instantiate(grenadePrefab, transform);
        grenade.transform.position = cam.transform.position + cam.transform.forward * 2;
        Rigidbody grenadeRb = grenade.GetComponent<Rigidbody>();
        Vector3 impulse = cam.transform.forward * finalImpulse;
        grenadeRb.AddForceAtPosition(impulse, cam.transform.position, ForceMode.Impulse);

        Explosion explosion = grenade.GetComponent<Explosion>();
        explosion.explosionParticlesPrefab = particleSysPrefab;
    }

    public void EquipWeapon(GameObject weaponPrefab)
    {
        if (currentWeapon != null)
        {
            // Destroy the existing weapon instance
            Destroy(currentWeapon.gameObject);
        }

        // Instantiate the new weapon
        GameObject weaponInstance = Instantiate(weaponPrefab);

        // Get the Weapon component
        currentWeapon = weaponInstance.GetComponent<Weapon>();

        if (currentWeapon != null)
        {
            // Set the weapon's position relative to the camera
            weaponInstance.transform.SetParent(cam.transform); // Make the weapon a child of the camera
            weaponInstance.transform.localPosition = new Vector3(1f, -1.5f, 1.5f);
            weaponInstance.transform.localRotation = Quaternion.Euler(0, -90, 0); // Adjust rotation if necessary

            currentWeapon.Initialize(cam); // Pass the camera reference
        }
        else
        {
            Debug.LogError("Weapon component not found on the instantiated weapon prefab.");
        }
    }

}
