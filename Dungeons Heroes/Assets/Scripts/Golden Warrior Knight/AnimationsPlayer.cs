using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnimationsPlayer : MonoBehaviour
{
   
  
     /*
    void Update(){
    if(Input.GetKey(KeyCode.S){
        ThrowBomb();
    }
    void ThrowBomb(){
        GameObject bomb = Instiantate(bombThrow,transform.position,transform.rotation);
        Rightbody rb = grenade.GetComponent<Rigidbody>();
        rb.addForce(transform.forward * throwForce),ForceMode.VelocityChange;
    }
    */
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
    public float throwForce;
    public GameObject bombThrow;
    public GameObject sword;
    public ParticleSystem explosion;
    public swordCollider swordScript;
    public bool invencible = false;
    public Collider coll;
    private float HP_Min_aux = 100;
    private float sword_x, sword_y, sword_z;
    public bool throweable = true;

    public AudioClip sword_sound;

    public AudioSource attackAudioSource;
    void Start()
    {
        attackAudioSource = GetComponent<AudioSource>();
        coll = GetComponent<Collider>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        run_speed =2 *speed ;
        sword = GameObject.Find("sword");
        swordScript = sword.GetComponent<swordCollider>();
        swordCollider = sword.GetComponent<Collider>();
        sword_x = transform.localScale.x;
        sword_y = transform.localScale.y;
        sword_z = transform.localScale.z;
        ScaleSword();
    }

    void ScaleSword()
    {
        float value = HP_Min / HP_Max;
        if (value <= 0) value = 2;
        else if (value <= 0.1) value = 1.9f;
        else if (value <= 0.2) value = 1.8f;
        else if (value <= 0.3) value = 1.7f;
        else if (value <= 0.4) value = 1.6f;
        else if (value <= 0.5) value = 1.5f;
        else if (value <= 0.6) value = 1.4f;
        else if (value <= 0.7) value = 1.3f;
        else if (value <= 0.8) value = 1.2f;
        else if (value <= 0.9) value = 1.1f;
        else value = 1f;
        //sword.transform.localScale = new Vector3(sword_x/4*value, sword_y/4*value, sword_z/4*value); 
        sword.transform.localScale = new Vector3(sword_x/transform.localScale.x*2/value, sword_y/transform.localScale.y * 2/value, sword_z/transform.localScale.z * 2 / value); 
    }
 
    
        /*
        void OnCollisionEnter(Collision collisionInfo)
        {

            if (collisionInfo.collider.tag == "Obstacle")
            {
                Physics.IgnoreCollision(collisionInfo.collider, swordCollider);
            }
            else if (collisionInfo.collider.tag == "Enemy")
            {
                GameObject collidedObject = collisionInfo.gameObject;
        */
        //float forceMagnitude = 50.0f;
        /*
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
        */
        /*Vector3 forceDirection = transform.forward;
        forceDirection.y = 0;
        forceDirection.Normalize();
        rb.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
        */
        // rb.AddForce(-transform.forward * 50.0f, ForceMode.Impulse);
        // rb.AddForce(Vector3.forward * forceMagnitude, ForceMode.Impulse);
        /*
    }
}
}

if (!found)
{
HP_Min -= 20;
Debug.Log("hp:MIn Player: " + HP_Min);
}
        */
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
        /*
        Debug.Log("Contacto enemigo desde player");
    }
}
        */
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
            speed = 8f;
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


        if (HP_Min > 0)
        {
            //sword.transform.localScale = new Vector3(transform.localScale.x * 0.2f/(HP_Max/HP_Min), transform.localScale.y * 0.2f, transform.localScale.z * 0.2f);
            ScaleSword();

            Movement();
            if (Input.GetKeyDown(KeyCode.J)){
                if(throweable) ThrowBomb();
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                animator.Play("one_hand_attack1");
                swordCollider.enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (!AnimatorIsPlaying("one_hand_attack2")) attackAudioSource.PlayOneShot(sword_sound, 0.7F);
                animator.Play("one_hand_attack2");
                swordCollider.enabled = true;
                
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                animator.Play("two_hand_attack1");
                swordCollider.enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                animator.Play("two_hand_attack2");
                swordCollider.enabled = true;
                attackAudioSource.Play();
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                invencible = !invencible;
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                //OBTENER LLAVE
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                //OBTENER LLAVE BOSS
            }


            // barra.fillAmount = HP_Min / HP_Max;
        }
       else
        {
            if (!dead)
            {
                animator.Play("die");
                //music.enabled = false;
                dead = true;
                //Aparecer pantalla lose
                //Invoke("EliminateObject", 1.0f);
            }
        }

    }

    void ThrowBomb()
    {
        Vector3 currentPosition = transform.position;
        Vector3 posit = new Vector3(currentPosition.x, currentPosition.y + 2.0f, currentPosition.z);
        GameObject bomb = Instantiate(bombThrow, posit, transform.rotation);
        bomb.SetActive(true);
        Debug.Log(bomb.name);
        //Debug.Log("Throw");
        bomb.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        Rigidbody rb = bomb.GetComponent<Rigidbody>();
        //print(rb.mass);
        rb.AddForce(transform.forward * throwForce,ForceMode.VelocityChange);
        throweable = false;
        Invoke("ExplosionEffect", 2.0f);
    }
    
    void ExplosionEffect()
    {
        throweable = true;
        /*
        explosion.transform.position = bomb.transform.position;
        explosion.Play();
        */
    }
        private void FixedUpdate()
    {

    }
}
