using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBehaviour : Enemy
{


    protected override void Start()
    {
        base.Start();
    }


    protected override bool AnimatorIsPlaying()
    {
        return base.AnimatorIsPlaying();
    }

    protected override bool AnimatorIsPlaying(string stateName)
    {
        return AnimatorIsPlaying() && animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }

    void KinematicF()
    {
        rigidbody.isKinematic = false;
    }


    void OnTriggerEnter(Collider collid)
    {

        if (collid.tag == "Obstacle")
        {
            rigidbody.isKinematic = true;
            Invoke("KinematicF", 0.1f);
        }
        if (!entered)
        {

            if (collid.name == "Player" && !playerScript.invencible)
            {
                playerScript.HP_Min -= 10;
                if (playerScript.dead == false)
                {
                    playerScript.animator.Play("hurt");
                    playerScript.audioSourceHurt.PlayOneShot(playerScript.hurt_sound, 0.3F);
                    Vector3 forceDirection = transform.forward;
                    float forceMagnitude = 600.0f;
                    // rigidbody.velocity = forceDirection;
                    playerScript.rigidbody.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
                }
            }
            else if (collid.name == "sword")
            {
                Debug.Log(collid.name);
                entered = true;
                Invoke("Delay", 1.0f);
                HP_Min -= 25;
                rutina = 1;
            }

        }
    }
    /*
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
    */
    protected override void bossIA()
    {
        base.bossIA();
        if (Vector3.Distance(transform.position, target.transform.position) < 30)
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            //music.enabled = true;


            if (Vector3.Distance(transform.position, target.transform.position) > 1)
            {
                if (rutina != 1 && Vector3.Distance(transform.position, target.transform.position) < 2.8) rutina = 2;
                else
                {
                    if (rutina != 1) rutina = 0;
                }
                switch (rutina)
                {
                    case 0:  ///Walk
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        animator.Play("Walk");
                        if (!AnimatorIsPlaying("Attack1")) transform.Translate(Vector3.forward * speed * Time.deltaTime);
                        break;

                    case 1: //TakeDamage
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        if (!hurt)
                        {
                            audioSourceHurt.PlayOneShot(hurt_sound, 0.3F);
                            hurt = true;
                        }
                        animator.Play("TakeDamage");
                        move_force();
                        Invoke("ChangeAnimation", 0.5f);
                        //if(transform.rotation == rotation) transform.Translate(Vector3.forward * speed*2 * Time.deltaTime);
                        transform.Translate(Vector3.forward * speed * 2 * Time.deltaTime);
                        break;

                    case 2: //Attack
                        animator.Play("Attack1");
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        break;

                }
            }
        }
       // else animator.Play("Idle");
    }



    protected override void move_force()
    {
        base.move_force();
    }
    protected override void ChangeAnimation()
    {
        base.ChangeAnimation();
    }
    protected override void EliminateObject()
    {
        base.EliminateObject();
    }

    // Update is called once per frame
    protected override void Update()
    {
        //hpBar.fillAmount = HP_Min / HP_Max;
        base.Update();


    }
}
