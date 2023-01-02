using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lich : MonoBehaviour
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

    ///////////////////////////////   FireBall
    public GameObject fireBall;
    public GameObject point;
    public List<GameObject> pool2 = new List<GameObject>();

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
        GameObject obj = Instantiate(fireBall, point.transform.position, point.transform.rotation) as GameObject;
        pool2.Add(obj);
        return obj;
    }

    public void FireBallSkill()
    {
        GameObject obj = GetFireBall();
        obj.transform.position = point.transform.position;
        obj.transform.rotation = point.transform.rotation;
    }


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
        if (Vector3.Distance(transform.position, target.transform.position) < 8)
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            //music.enabled = true;


            if (Vector3.Distance(transform.position, target.transform.position) > 2)
            {
                if (Vector3.Distance(transform.position, target.transform.position) < 6)
                {
                    rutina = 2;
                }
                else
                {
                    rutina = 0;
                }
                switch (rutina)
                {
                    case 0:  ///Walk
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        animator.Play("walk");
                        //animator.SetBool("attack01", false);
                        //animator.SetBool("attack02", false);
                        if (!AnimatorIsPlaying("attack01") && !AnimatorIsPlaying("attack02")) transform.Translate(Vector3.forward * speed * Time.deltaTime);
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
                        animator.Play("attack01");
                        //animator.SetBool("attack01", true);
                        //animator.SetBool("attack02", false);
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
                animator.Play("die");
                //music.enabled = false;
                //dead = true;

                Invoke("EliminateObject", 2.0f);
            }
        }

    }
}
