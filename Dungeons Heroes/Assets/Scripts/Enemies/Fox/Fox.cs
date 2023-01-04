using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : Enemy
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
                Debug.Log(HP_Min);
                if (playerScript.dead == false)
                {
                    playerScript.animator.Play("hurt");
                    Vector3 forceDirection = transform.forward;
                    float forceMagnitude = 600.0f;
                    // rigidbody.velocity = forceDirection;
                    playerScript.rigidbody.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
                }
            }
            else if(collid.name == "sword")
            {
                if (!(animator.GetCurrentAnimatorStateInfo(0).IsName("Defend"))) {
                    entered = true;
                    Invoke("Delay", 1.0f);
                    HP_Min -= 25;
                    rutina = 1;
                }
                else
                {
                    //sound shield
                }
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

            if (Vector3.Distance(transform.position, target.transform.position) > 1.0)
            {
                if (rutina != 1 && Vector3.Distance(transform.position, target.transform.position) < 2)
                {
                    if (!AnimatorIsPlaying("Attack01") && !AnimatorIsPlaying("Attack02") && !AnimatorIsPlaying("Defend"))
                    {
                        int action = Random.Range(2, 5);
                        if (action != rutina) rutina = action;
          
                    }
                }
                else
                {
                    if(rutina !=1) rutina = 0;
                }
                switch (rutina)
                {
                    case 0:  ///Walk
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        animator.Play("WalkForwardBattle");
                        if (!AnimatorIsPlaying("Attack01") && !AnimatorIsPlaying("Attack02") && !AnimatorIsPlaying("Defend")) transform.Translate(Vector3.forward * speed * Time.deltaTime);
                        break;
                    
                    case 1: //TakeDamage
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        animator.Play("GetHit");
                        move_force();
                        
                        //if(transform.rotation == rotation) transform.Translate(Vector3.forward * speed*2 * Time.deltaTime);
                        //transform.Translate(Vector3.forward * speed * 2 * Time.deltaTime);
                        Invoke("ChangeAnimation", 0.5f);
                        break;
                    case 2: //Attack
                        animator.Play("Attack01");
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        break;
                    case 3: //Attack2
                        animator.Play("Attack02");
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        break;
                    case 4: //Defend
                        animator.Play("Defend");
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        break;

                }
            }
        }
        else animator.Play("Idle_Battle");
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
