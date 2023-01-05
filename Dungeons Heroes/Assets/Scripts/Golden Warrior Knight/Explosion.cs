using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float timer = 0.7f;
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

    void OnCollsionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            has_exploded = true;
            GameObject spawnedParticle = Instantiate(explosionParticle, transform.position, transform.rotation);
            Destroy(spawnedParticle, 1);
            Component[] components = coll.gameObject.GetComponents(typeof(Component));
            foreach (Component c in components)
            {
                if (c is Fox)
                {
                    Fox script = (Fox)c;
                    script.HP_Min = 0;
                }
                else if(c is Slime)
                {
                    Slime script = (Slime)c;
                    script.HP_Min = 0;
                }
                else if(c is SpiderBehaviour)
                {
                    SpiderBehaviour script = (SpiderBehaviour)c;
                    script.HP_Min = 0;
                }
                else if (c is Lich)
                {
                    Lich script = (Lich)c;
                    script.HP_Min = 0;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        its_happening -= Time.deltaTime;
        if (!has_exploded)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            int arraySize = colliders.Length;
            foreach (Collider nearbyObject in colliders)
            {
                if (nearbyObject.tag == "Enemy")
                {
                    has_exploded = true;
                    its_happening = -1.0f;
                    GameObject spawnedParticle = Instantiate(explosionParticle, transform.position, transform.rotation);
                    Destroy(spawnedParticle, 1);
                    Component[] components = nearbyObject.gameObject.GetComponents(typeof(Component));
                    foreach (Component c in components)
                    {
                        if (c is Fox)
                        {
                            Fox script = (Fox)c;
                            script.HP_Min = -1.0f;
                        }
                        else if (c is Slime)
                        {
                            Slime script = (Slime)c;
                            script.HP_Min = -1.0f;
                        }
                        else if (c is SpiderBehaviour)
                        {
                            SpiderBehaviour script = (SpiderBehaviour)c;
                            script.HP_Min = -1.0f;
                        }
                        else if (c is Lich)
                        {
                            Lich script = (Lich)c;
                            script.HP_Min = -1.0f;
                        }
                    }
                }
            }
            if (its_happening <= 0) Explode();
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
