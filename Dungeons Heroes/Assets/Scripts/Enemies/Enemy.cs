using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public int rutina;
    public Animator animator;
    public Quaternion angle;
    public GameObject target;
    public Rango range;
    public float speed;

    public GameObject coin;
    public GameObject heart;

    bool drop = false;

    /////////////
    public bool entered = false;
    public float HP_Min;
    public float HP_Max;
    //public AudioSource music;
    public bool hit = false;
    public bool dead;
    //public Image hpBar;
    public AnimationsPlayer playerScript;

    protected virtual void Delay()
    {
        entered = false;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        target = GameObject.Find("Player");
        playerScript = target.GetComponent<AnimationsPlayer>();
    }

    protected virtual bool AnimatorIsPlaying()
    {
        return animator.GetCurrentAnimatorStateInfo(0).length > 0;
    }

    protected virtual bool  AnimatorIsPlaying(string stateName)
    {
        return AnimatorIsPlaying() && animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }

    protected virtual void bossIA()
    {
        int x;
    }

    protected virtual void move_force()
    {
        Vector3 forceDirection = -transform.forward;
        float forceMagnitude = 4.0f;
        rigidbody.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
    }
    protected virtual void ChangeAnimation()
    {
        rutina = 0;
        rigidbody.velocity = Vector3.zero;
    }
    protected virtual void EliminateObject()
    {
        int x = Random.Range(1, 5);
        Vector3 currentPosition = transform.position;
        Vector3 spawn_position = new Vector3(currentPosition.x, currentPosition.y + 0.5f, currentPosition.z);
        if (x == 1)
        {
            Instantiate(coin, spawn_position, transform.rotation);
            drop = true;
        }
        else if (!drop && x == 2)
        {
            Instantiate(heart, spawn_position, transform.rotation);
        }
        drop = false;
        Destroy(gameObject);
    }

    // Update is called once per frame
    protected virtual void Update()
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
