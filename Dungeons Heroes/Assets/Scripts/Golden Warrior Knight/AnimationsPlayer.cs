using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnimationsPlayer : MonoBehaviour
{

    private new Rigidbody rigidbody;

    [SerializeField] private float speed = 2f;

    public Animator animator;
    public float raycastDistance;
    private int isColliding = 0;


    public float health;
    private float sizeWeapon;
    // transform.localScale = new Vector3(2, transform.localScale.y, transform.localScale.z);
    private float run_speed;
    public float HP_Min;
    public float HP_Max;
    public Image barra;
    private Collider swordCollider;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        run_speed = speed * 2;

        GameObject sword = GameObject.Find("sword");
        swordCollider = sword.GetComponent<Collider>();
        //swordCollider.isTrigger = true;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Floor")
        {

         
        }
        else if (collisionInfo.collider.tag == "Obstacle")
        {
          
            isColliding = 1;

        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {

         
            isColliding = 2;
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            isColliding = 0;
        }
    }

    bool AnimatorIsPlaying()
    {
        return animator.GetCurrentAnimatorStateInfo(0).length > 0;
    }

    bool AnimatorIsPlaying(string stateName)
    {
        return AnimatorIsPlaying() && animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }

    void debugAnimation()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        if (clipInfo.Length > 0)
        {
            string animationName = clipInfo[0].clip.name;
            Debug.Log("Currently playing animation: " + animationName);
        }
    }
    void Movement()
    {
        Vector3 moveDirection = Vector3.zero;
        bool not_attacking = AnimatorIsPlaying("walk") || AnimatorIsPlaying("idle") || AnimatorIsPlaying("run");
        if (not_attacking)
        {
            swordCollider.enabled = false;
            swordCollider.isTrigger = true;
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.H))
                {
                    animator.Play("run");
                    moveDirection += Vector3.back;
                    speed = run_speed;
                    animator.SetBool("Run", true);
                }
                else
                {
                    animator.SetBool("Run", false);
                    animator.Play("walk");
                    moveDirection += Vector3.back;

                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.H))
                {
                    animator.Play("run");
                    moveDirection += Vector3.forward;
                    speed = run_speed;
                    animator.SetBool("Run", true);
                }
                else
                {
                    animator.SetBool("Run", false);
                    animator.Play("walk");
                    moveDirection += Vector3.forward;

                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                if (Input.GetKey(KeyCode.H))
                {
                    animator.SetBool("Run", true);
                    animator.Play("run");
                    moveDirection += Vector3.right;
                    speed = run_speed; ;

                }
                else
                {
                    animator.SetBool("Run", false);
                    animator.Play("walk");
                    moveDirection += Vector3.right;

                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.H))
                {
                    animator.SetBool("Run", true);
                    animator.Play("run");
                    moveDirection += Vector3.left;
                    speed = run_speed;

                }
                else
                {
                    animator.SetBool("Run", false);
                    animator.Play("walk");
                    moveDirection += Vector3.left;

                }

            }
        }

        moveDirection = moveDirection.normalized;

        moveDirection *= speed * Time.deltaTime;

        //if (isColliding == 1) moveDirection = Vector3.zero;
        //else if (isColliding == 2) moveDirection = Vector3.zero;
        transform.position += moveDirection;

        rigidbody.MovePosition(rigidbody.position + moveDirection);
        var velocity = moveDirection / Time.deltaTime;
        animator.SetFloat("Speed", velocity.magnitude);

        if (moveDirection != Vector3.zero)
        {
            transform.LookAt(transform.position + moveDirection);
        }


    }


    void Update()
    {
        speed = 2f;

        Movement();

        if (Input.GetKey(KeyCode.V))
        {
            animator.Play("one_hand_attack1");
            swordCollider.enabled = true;
        }
        if (Input.GetKey(KeyCode.X))
        {
            animator.Play("one_hand_attack2");
            swordCollider.enabled = true;
        }
        if (Input.GetKey(KeyCode.C))
        {
            animator.Play("two_hand_attack1");
            swordCollider.enabled = true;
        }
        if (Input.GetKey(KeyCode.Z))
        {
            animator.Play("two_hand_attack2");
            swordCollider.enabled = true;
        }
        if (Input.GetKey(KeyCode.B))
        {
            animator.Play("hurt");
        }
        if (Input.GetKey(KeyCode.N)) animator.Play("die");


        barra.fillAmount = HP_Min / HP_Max;


    }

    private void FixedUpdate()
    {

    }
}
