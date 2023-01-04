using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float timer = 1.6f;
    float its_happening;
    float radius;
    float force = 500.0f;
    bool has_exploded;
    [SerializeField] GameObject explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        its_happening = timer;
        radius = 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        its_happening -= Time.deltaTime;
        if (its_happening <= 0 && !has_exploded)
        {
            Explode();
        }
    }
    void Explode()
    {
        GameObject spawnedParticle = Instantiate(explosionParticle, transform.position, transform.rotation);
        Destroy(spawnedParticle,1);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        int arraySize = colliders.Length;
        foreach(Collider nearbyObject in colliders)
        {
            Debug.Log(nearbyObject.name);
            if (nearbyObject.tag == "Enemy")
            {
                Destroy(nearbyObject.gameObject);
            }
            else if (nearbyObject.tag == "Diana")
            {
              Debug.Log("Dianaaaaaaaaaa");
              Destroy(nearbyObject.gameObject);
            }
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        has_exploded = true;
        Destroy(gameObject);
    }
}
