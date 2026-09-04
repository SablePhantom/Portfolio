using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Explosion : MonoBehaviour
{
    public float radius = 5.0f;
    public float power = 10.0f;
    public GameObject explosionParticlesPrefab;
    void OnCollisionEnter(Collision collision)
    {
        if (explosionParticlesPrefab != null)
        {
            Instantiate(explosionParticlesPrefab, transform.position, Quaternion.identity);
        }

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPos, radius, 3.0f, ForceMode.Impulse);
            }
            //ColorChange colorChange = hit.GetComponent<ColorChange>();
           // if (colorChange != null)
            //{
           //     colorChange.SetRandomColor();
           // }
        }
        Destroy(gameObject);
    }
}