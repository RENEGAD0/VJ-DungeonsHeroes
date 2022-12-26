using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rango : MonoBehaviour
{

    public Animator animator;
    public Boss boss;
    public int melee;

    void OnTriggerEnter(Collider coll) {
        if(coll.CompareTag("Player")){
            melee = Random.Range(0, 2);
            switch (melee){
                case 0:
                animator.SetFloat("skills", 0);
                boss.hit_Select = 0;
                break;
                case 1:
                animator.SetFloat("skills", 0.25f);
                boss.hit_Select = 1;
                break;
                case 2:
                if(boss.fase == 2)animator.SetFloat("skills", 0.75f);
                else melee = 0;
                break;
            }
                animator.SetBool("walk", false);
                animator.SetBool("run", false);
                animator.SetBool("atack", true);
                boss.isAtacking = true;
                GetComponent<CapsuleCollider>().enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
