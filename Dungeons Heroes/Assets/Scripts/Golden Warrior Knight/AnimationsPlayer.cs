using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
=======
using UnityEngine.UI;
>>>>>>> Stashed changes

public class AnimationsPlayer : MonoBehaviour
{  
    
<<<<<<< Updated upstream
    private Rigidbody rigidbody;

    public float speed;
    public Animator animator;
    public float raycastDistance;
    private int isColliding = 0;
=======
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
>>>>>>> Stashed changes
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
<<<<<<< Updated upstream
=======
        run_speed = speed * 2;
>>>>>>> Stashed changes
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Floor")
        {

            UnityEngine.Debug.Log(collisionInfo);
        }
        else if (collisionInfo.collider.tag == "Obstacle")
        {
            
            UnityEngine.Debug.Log("Objects");
            isColliding = 1;
<<<<<<< Updated upstream
=======

            Vector3 surfaceNormal = collisionInfo.contacts[0].normal;
            Vector3 pushDirection = surfaceNormal;
       
            float force = 20.0f;
            Vector3 v = pushDirection;

            Vector3 result = force * v;

            rigidbody.AddForce(result, ForceMode.Impulse);

>>>>>>> Stashed changes
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
       if (collisionInfo.collider.tag == "Obstacle")
        {

            UnityEngine.Debug.Log("Objects");
            isColliding = 2;
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            isColliding = 0;
        }
<<<<<<< Updated upstream
       
    }
    /*
    void GetBombToHand()
    {
        transform.position 
    }
    */
        // Update is called once per frame
        void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            animator.Play("walk");
            moveDirection += Vector3.back;
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.Play("walk");
            moveDirection += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.Play("walk");
            moveDirection += Vector3.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.Play("walk");
            moveDirection += Vector3.left;
        }

       
=======
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
        bool attacking = AnimatorIsPlaying("walk") || AnimatorIsPlaying("idle") || AnimatorIsPlaying("run");
        if (attacking)
        {
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
                    animator.Play("walk");
                    moveDirection += Vector3.back;
                    animator.SetBool("Run", false);
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
                    animator.Play("walk");
                    moveDirection += Vector3.forward;
                    animator.SetBool("run", false);
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                if (Input.GetKey(KeyCode.H))
                {
                    animator.Play("run");
                    moveDirection += Vector3.right;
                    speed = run_speed; ;
                    animator.SetBool("Run", true);
                }
                else
                {
                    animator.Play("walk");
                    moveDirection += Vector3.right;
                    animator.SetBool("Run", false);
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.H))
                {
                    animator.Play("run");
                    moveDirection += Vector3.left;
                    speed = run_speed;
                    animator.SetBool("run", true);
                }
                else
                {
                    animator.Play("walk");
                    moveDirection += Vector3.left;
                    animator.SetBool("run", false);
                }

            }
        }

>>>>>>> Stashed changes
        moveDirection = moveDirection.normalized;

        moveDirection *= speed * Time.deltaTime;

<<<<<<< Updated upstream
        if (isColliding == 1) moveDirection = Vector3.zero;
        else if (isColliding == 2) moveDirection = Vector3.zero;
        transform.position += moveDirection;

        rigidbody.MovePosition(rigidbody.position + moveDirection);

=======
        //if (isColliding == 1) moveDirection = Vector3.zero;
        //else if (isColliding == 2) moveDirection = Vector3.zero;
        transform.position += moveDirection;

        rigidbody.MovePosition(rigidbody.position + moveDirection);
        var velocity = moveDirection / Time.deltaTime;
        animator.SetFloat("Speed", velocity.magnitude);
>>>>>>> Stashed changes
        if (moveDirection != Vector3.zero)
        {
            transform.LookAt(transform.position + moveDirection);
        }
<<<<<<< Updated upstream

        if (Input.GetKeyDown(KeyCode.Z)) animator.Play("one_hand_attack1");
        if (Input.GetKeyDown(KeyCode.X)) animator.Play("one_hand_attack2");
        if (Input.GetKeyDown(KeyCode.C)) animator.Play("two_hand_attack1");
        if (Input.GetKeyDown(KeyCode.V)) animator.Play("two_hand_attack2");
        if (Input.GetKeyDown(KeyCode.B)) animator.Play("hurt");
        if (Input.GetKeyDown(KeyCode.N)) animator.Play("die");
        /*
        // Create a ray using the origin and direction
        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

        if(Physics.Raycast(theRay,out RaycastHit hit, range))
        {
            if(hit.collider.tag == "Obstacles")
            {
                UnityEngine.Debug.Log("SDASDASDASDAS");
            }
         //
        }
        */
=======
    }

    /*
    void GetBombToHand()
    {
        transform.position 
    }
    */
   
    void Update()
    {
        speed = 2f;

        Movement();

        if (Input.GetKey(KeyCode.V))
        {
            animator.Play("one_hand_attack1");
        }
        if (Input.GetKey(KeyCode.X))
        {
            animator.Play("one_hand_attack2");
        }
        if (Input.GetKey(KeyCode.C))
        {
            animator.Play("two_hand_attack1");
        }
        if (Input.GetKey(KeyCode.Z))
        {
            animator.Play("two_hand_attack2");
        }
        if (Input.GetKey(KeyCode.B))
        {
            animator.Play("hurt");
        }
        if (Input.GetKey(KeyCode.N)) animator.Play("die");
        
    
        barra.fillAmount = HP_Min / HP_Max;
        
>>>>>>> Stashed changes
    }

    private void FixedUpdate()
    {

    }
}
<<<<<<< Updated upstream
=======

/*
      // Create a ray using the origin and direction
      Vector3 direction = Vector3.forward;
      Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
      Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

      if(Physics.Raycast(theRay,out RaycastHit hit, range))
      {
          if(hit.collider.tag == "Obstacles")
          {
              UnityEngine.Debug.Log("SDASDASDASDAS");
          }
       //
      }
      */
>>>>>>> Stashed changes
