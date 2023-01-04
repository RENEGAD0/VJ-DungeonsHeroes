using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lich : Enemy
{
    
    public GameObject electricBall;
    public bool delay = false;
    /*
    public GameObject GetFireBall()
    {
        for (int i = 0; i < pool2.Count; ++i)
        {
            if (!pool2[i].activeInHierarchy)
            {
                pool2[i].SetActive(true);
                return pool2[i];
            }
        }
        GameObject obj = Instantiate(fireBall, transform.position, transform.rotation) as GameObject;
        pool2.Add(obj);
        return obj;
    }

    public void FireBallSkill()
    {
        GameObject obj = GetFireBall();
        obj.transform.position = point.transform.position;
        obj.transform.rotation = point.transform.rotation;
    }
    //point.transform.LookAt(target.transform.position);
    
    */
    protected override void Delay()
    {
        base.Delay();
    }

    void StopDelay()
    {
        delay = false;
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
        if (Vector3.Distance(transform.position, target.transform.position) < 14)
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            //music.enabled = true;


            if (Vector3.Distance(transform.position, target.transform.position) > 2)
            {
                if (rutina != 1 && Vector3.Distance(transform.position, target.transform.position) < 3)
                {
                    rutina = 3;
                }
                else if (rutina != 1 && Vector3.Distance(transform.position, target.transform.position) < 7)
                {
                    if(!delay) rutina = 2;
                    else
                    {
                        rutina = 3;
                    }
                }
                else
                {
                    if (rutina != 1) rutina = 0;
                }
                switch (rutina)
                {
                    case 0:  ///Walk
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        animator.Play("walk");
                        if (!AnimatorIsPlaying("attack01") && !AnimatorIsPlaying("attack02")) transform.Translate(Vector3.forward * speed * Time.deltaTime);
                        break;
                    case 1: //TakeDamage
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        animator.Play("GetHit");
                        move_force();
                        Invoke("ChangeAnimation", 0.8f);
                        //if(transform.rotation == rotation) transform.Translate(Vector3.forward * speed*2 * Time.deltaTime);
                        transform.Translate(Vector3.forward * speed * 2 * Time.deltaTime);
                        break;
                    case 2: //Attack
                        if (!delay)
                        {
                            animator.Play("attack01");
                            Invoke("ThrowBall", 0.1f);
                            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                            delay = true;
                            Invoke("StopDelay", 3.0f);
                        }
                        break;
                    case 3: //Attack
                        animator.Play("attack02");
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        break;

                }
            }
            else
            {
                //animator.SetBool("attack02", true);
                //animator.SetBool("attack01", false);
                animator.Play("attack02");
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
            }
        }
        else animator.Play("idle");
    }
    void ThrowBall()
    {
        Vector3 currentPosition = transform.position;
        Vector3 posit = new Vector3(currentPosition.x, currentPosition.y + 1.0f, currentPosition.z);

        Vector3 position = posit + transform.forward * 3.0f;
        GameObject el_ball = Instantiate(electricBall, position, transform.rotation);
        Rigidbody rb = el_ball.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 4.0f, ForceMode.VelocityChange);

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
