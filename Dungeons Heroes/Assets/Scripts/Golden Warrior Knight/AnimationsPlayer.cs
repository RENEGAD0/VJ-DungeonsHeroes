using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnimationsPlayer : MonoBehaviour
{

    public new Rigidbody rigidbody;

    [SerializeField] private float speed = 2f;

    public Animator animator;
    public float raycastDistance;

    public float health;
    private float sizeWeapon;
    // transform.localScale = new Vector3(2, transform.localScale.y, transform.localScale.z);
    private float run_speed;
    public float HP_Min;
    public float HP_Max;
    //public Image barra;
    private Collider swordCollider;
    public bool dead;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        run_speed =2 *speed ;
        GameObject sword = GameObject.Find("sword");
        swordCollider = sword.GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.collider.tag == "Obstacle")
        {
            Physics.IgnoreCollision(collisionInfo.collider, swordCollider);
        }
        else if (collisionInfo.collider.tag == "Enemy")
        {
            GameObject collidedObject = collisionInfo.gameObject;
            //float forceMagnitude = 50.0f;
            Vector3 force;
            float distance;
            force = transform.forward;
            distance = 0.1f;
            bool found = false;
            foreach (ContactPoint contact in collisionInfo.contacts)
            {
                if (contact.thisCollider.name == "sword")
                {
                    found = true;
                    Debug.Log("Collider with name " + contact.thisCollider.name + " was involved in the collision");
                    Rigidbody rb = collidedObject.GetComponent<Rigidbody>();

                    if (rb != null)
                    {
                        float impulse = rb.mass * distance / Time.fixedDeltaTime;
                        rb.AddForce(force * impulse, ForceMode.Impulse);
                        /*Vector3 forceDirection = transform.forward;
                        forceDirection.y = 0;
                        forceDirection.Normalize();
                        rb.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
                        */
                        // rb.AddForce(-transform.forward * 50.0f, ForceMode.Impulse);
                        // rb.AddForce(Vector3.forward * forceMagnitude, ForceMode.Impulse);
                    }
                }
            }

            if (!found)
            {
                HP_Min -= 20;
                Debug.Log("hp:MIn Player: " + HP_Min);
            }
            /*
            Rigidbody rb = collidedObject.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    Vector3 forceDirection = transform.forward;
                    forceDirection.y = 0;

                    // Normalize the force direction
                    forceDirection.Normalize();

                    // Apply the force in the calculated direction
                    rb.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
                    //rb.AddForce(-transform.forward * 50.0f, ForceMode.Impulse);
                    //rb.AddForce(Vector3.forward * forceMagnitude, ForceMode.Impulse);
                }
            */
            
            Debug.Log("Contacto enemigo desde player");
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
          
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
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
            speed = 4f;
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

        transform.position += moveDirection;

        rigidbody.MovePosition(rigidbody.position + moveDirection);
        var velocity = moveDirection / Time.deltaTime;
        animator.SetFloat("Speed", velocity.magnitude);

        if (moveDirection != Vector3.zero)
        {
            transform.LookAt(transform.position + moveDirection);
        }


    }


    void die()
    {
        animator.SetBool("dead", true);
        //animator.Play("dead");
        //music.enabled = false;
        dead = true;

        Invoke("EliminateObject", 1.0f);
    }
    void Update()
    {
     

       if(HP_Min > 0)
        {

        
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


            // barra.fillAmount = HP_Min / HP_Max;
        }
       else
        {
            if (!dead)
            {
                animator.SetBool("dead", true);
                animator.Play("die");
                //music.enabled = false;
                dead = true;
                //Aparecer pantalla lose
                //Invoke("EliminateObject", 1.0f);
            }
        }

    }

    private void FixedUpdate()
    {

    }
}
