using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float timer = 2;
    float countdown;
    float radius;
    float force = 500.0f;
    bool has_exploded;
    [SerializeField] GameObject explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        countdown = timer;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && !has_exploded)
        {
            Explode();
           
        }
    }
    void Explode()
    {
        GameObject spawnedParticle = Instantiate(explosionParticle, transform.position, transform.rotation);
        Destroy(spawnedParticle,1);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        has_exploded = true;
        Destroy(gameObject);

        print("Explosion");
    }
}
