using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    // public float speed = 10.0f;
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z)) animator.SetTrigger("onehandattack1");
        if (Input.GetKeyDown(KeyCode.X)) animator.SetTrigger("onehandattack2");
        if (Input.GetKeyDown(KeyCode.Space)) animator.SetTrigger("walk");
        if (Input.GetKeyDown(KeyCode.C)) animator.SetTrigger("twohandattack1");
        if (Input.GetKeyDown(KeyCode.V)) animator.SetTrigger("twohandattack2");
        if (Input.GetKeyDown(KeyCode.B)) animator.SetTrigger("hurt");
        if (Input.GetKeyDown(KeyCode.N)) animator.SetTrigger("die");

    }
    private void FixedUpdate()
    {

    }
}
