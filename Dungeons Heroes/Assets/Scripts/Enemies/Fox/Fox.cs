using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
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


    // Start is called before the first frame update
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

    void bossIA()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < 10)
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            //music.enabled = true;


            if (Vector3.Distance(transform.position, target.transform.position) > 1.0)
            {
                if (/*rutina != 1 &&*/ Vector3.Distance(transform.position, target.transform.position) < 1.1)
                {
                    if (!AnimatorIsPlaying("Attack01") && !AnimatorIsPlaying("Attack02") && !AnimatorIsPlaying("Defend"))
                    {
                        int  action = Random.Range(2, 5);
                        rutina = action;
                    }
                }
                else
                {
                    //if(rutina !=1)
                    rutina = 0;
                }
                switch (rutina)
                {
                    case 0:  ///Walk
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        animator.Play("WalkForwardBattle");
                        if (!AnimatorIsPlaying("Attack01") && !AnimatorIsPlaying("Attack02") && !AnimatorIsPlaying("Defend")) transform.Translate(Vector3.forward * speed * Time.deltaTime);
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

    public void EliminateObject()
    {
        //GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //hpBar.fillAmount = HP_Min / HP_Max;

        if (HP_Min > 0) bossIA();
        else
        {
            if (HP_Min <= 0) dead = true;
            if (dead)
            {
                //animator.SetBool("dead", true);
                animator.Play("Die");
                //music.enabled = false;
                //dead = true;

                Invoke("EliminateObject", 2.0f);
            }
        }

    }
}
