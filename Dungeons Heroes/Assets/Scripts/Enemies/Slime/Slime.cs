using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{   
    protected override void Delay()
    {
        base.Delay();
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

    // Start is called before the first frame update
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

    protected override void bossIA()
    {
        base.bossIA();
        if (Vector3.Distance(transform.position, target.transform.position) < 10)
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            //music.enabled = true;


            if (Vector3.Distance(transform.position, target.transform.position) > 1)
            {
                if (rutina != 1 && Vector3.Distance(transform.position, target.transform.position) < 1.5) rutina = 2;
                else
                {
                    if(rutina !=1) rutina = 0;
                }
                switch (rutina)
                {
                    case 0:  ///Walk
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        animator.Play("WalkFWD");
                        if (!AnimatorIsPlaying("Attack01")) transform.Translate(Vector3.forward * speed * Time.deltaTime);
                        break;
                     case 1: //TakeDamage
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        animator.Play("GetHit");
                        move_force();
                        Invoke("ChangeAnimation", 0.4f);
                        //if(transform.rotation == rotation) transform.Translate(Vector3.forward * speed*2 * Time.deltaTime);
                        transform.Translate(Vector3.forward * speed * 2 * Time.deltaTime);
                        break;
                    case 2: //Attack
                        animator.Play("Attack01");
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        break;

                }
            }
        }
        else animator.Play("IdleBattle");
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
