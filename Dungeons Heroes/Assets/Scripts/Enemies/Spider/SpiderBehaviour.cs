using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBehaviour : MonoBehaviour
{
    ////////////////////////////  Codigo enemigo base
    public new Rigidbody rigidbody;
    public int rutina;
    public Animator animator;
    public Quaternion angle;
    public GameObject target;
    public Rango range;
    public float speed;


    /////////////
    public float HP_Min;
    public float HP_Max;
    //public AudioSource music;
    public bool hit = false;
    public bool dead;
    //public Image hpBar;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    bool AnimatorIsPlaying()
    {
        return animator.GetCurrentAnimatorStateInfo(0).length > 0;
    }

    bool AnimatorIsPlaying(string stateName)
    {
        return AnimatorIsPlaying() && animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
    /*
    IEnumerator Timer(float waitTime)
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(waitTime);

        // Execute the action
        hit = false;
        Debug.Log("Timer expired!");
    }
*/
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player")
        {
            GameObject collidedObject = collisionInfo.gameObject;
            Vector3 force;
            float distance;
            force = transform.forward;
            distance = 0.05f;
            Debug.Log("Other Contact Player Collider: " + collisionInfo.collider.name);
            hit = true;
            //Timer(0.1f);
            bool found = false;
            foreach (ContactPoint contact in collisionInfo.contacts)
            {
                if (contact.thisCollider.name == "ColliderPota")
                {
                    Debug.Log("Other Contact: " + contact.otherCollider.name);
                    found = true;
                    Debug.Log("Collider with name " + contact.thisCollider.name + " was involved in the collision");
                    Rigidbody rb = collidedObject.GetComponent<Rigidbody>();

                    if (rb != null)
                    {
                        float impulse = rb.mass * distance / Time.fixedDeltaTime;
                        rb.AddForce(force * impulse, ForceMode.Impulse);
                        // rb.AddForce(-transform.forward * 50.0f, ForceMode.Impulse);
                        // rb.AddForce(Vector3.forward * forceMagnitude, ForceMode.Impulse);
                    }
                }
            }
            if(!found) doDmg();
        }
    }


    public void doDmg()
    {
        HP_Min -= 10;
        Debug.Log("hp:MIn: " + HP_Min);
       // rutina = 1;
    }

    public void bossIA()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < 30)
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            //music.enabled = true;
            
           
            if (Vector3.Distance(transform.position, target.transform.position) > 1)
            {
                if (/*rutina != 1 &&*/ Vector3.Distance(transform.position, target.transform.position) < 3) rutina = 2;
                else
                {
                    //if(rutina !=1)
                    rutina = 0;
                }
                switch (rutina)
                {
                    case 0:  ///Walk
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        animator.SetBool("walk", true);
                        animator.SetBool("take_damage", false);
                        animator.SetBool("attack", false);
                        if (! AnimatorIsPlaying("Attack1")) transform.Translate(Vector3.forward * speed * Time.deltaTime);
                        break;
                        /*
                    case 1: //TakeDamage
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        animator.SetBool("take_damage", true);
                        animator.SetBool("walk", false);
                        animator.SetBool("attack", false);
                        //if(transform.rotation == rotation) transform.Translate(Vector3.forward * speed*2 * Time.deltaTime);
                        transform.Translate(Vector3.forward * speed * 2 * Time.deltaTime);
                        break;
                ^*/
                    case 2: //Attack
                        animator.SetBool("take_damage", false);
                        animator.SetBool("walk", false);
                        animator.SetBool("attack", true);
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        break;

                }
            }


        }
    }


    public void EliminateObject()
    {
        //GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //hpBar.fillAmount = HP_Min / HP_Max;
        
        if (HP_Min > 0 ) bossIA();
        else
        {
            if (HP_Min <= 0) dead = true;
            if (dead)
            {
                animator.SetBool("dead",true);
                 // animator.Play("dead");
                //music.enabled = false;
                dead = true;
              
                Invoke("EliminateObject", 2.0f);
            }
        }

    }
}
