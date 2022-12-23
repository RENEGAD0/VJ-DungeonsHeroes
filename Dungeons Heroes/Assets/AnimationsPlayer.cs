using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.W))
        {
            animator.Play("walk");

            gameObject.transform.Translate(0.0f, 0.0f, -speed * Time.deltaTime, Space.World);
         //   gameObject.transform.Rotate(0.0f, 0.0f, -speed * Time.deltaTime, Space.World);
        }
           
        if (Input.GetKey(KeyCode.S))
        {
            animator.Play("walk");
            gameObject.transform.Translate(0.0f, 0.0f, speed * Time.deltaTime, Space.World);
        }
           
        if (Input.GetKey(KeyCode.A))
        {
            animator.Play("walk");
            gameObject.transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }
          
        if (Input.GetKey(KeyCode.D))
        {
            animator.Play("walk");
            gameObject.transform.Translate(-speed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.Z)) animator.Play("one_hand_attack1");
        if (Input.GetKeyDown(KeyCode.X)) animator.Play("one_hand_attack2");
        if (Input.GetKeyDown(KeyCode.C)) animator.Play("two_hand_attack1");
        if (Input.GetKeyDown(KeyCode.V)) animator.Play("two_hand_attack2");
        if (Input.GetKeyDown(KeyCode.B)) animator.Play("hurt");
        if (Input.GetKeyDown(KeyCode.N)) animator.Play("die");


    }

    private void FixedUpdate()
    {

    }
}
