using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsPlayer : MonoBehaviour
{  
    
    private Rigidbody rigidbody;

    public float speed;
    public Animator animator;
    public float raycastDistance;
    private int isColliding = 0;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
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

       
        moveDirection = moveDirection.normalized;

        moveDirection *= speed * Time.deltaTime;

        if (isColliding == 1) moveDirection = Vector3.zero;
        else if (isColliding == 2) moveDirection = Vector3.zero;
        transform.position += moveDirection;

        rigidbody.MovePosition(rigidbody.position + moveDirection);

        if (moveDirection != Vector3.zero)
        {
            transform.LookAt(transform.position + moveDirection);
        }

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
    }

    private void FixedUpdate()
    {

    }
}
