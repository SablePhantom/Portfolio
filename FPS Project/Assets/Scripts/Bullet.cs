using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10.0f; // Damage dealt by the bullet
    public GameObject hitEffectPrefab;

    void OnCollisionEnter(Collision collision)
    {
        // Detect if the bullet hits an object with the Shootable script
        Shootable target = collision.transform.GetComponent<Shootable>();
        if (target != null)
        {
            target.SetHealth((int)damage);
        }
        if (hitEffectPrefab != null)
        {
            Instantiate(hitEffectPrefab, collision.contacts[0].point, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}