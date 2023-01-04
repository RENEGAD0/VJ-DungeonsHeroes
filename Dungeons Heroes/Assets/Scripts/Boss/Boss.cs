using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour{
    ////////////////////////////  Codigo enemigo base
    public int rutina;
    public float tiempo_rutina;
    public float timer;
    public Animator animator;
    public Quaternion angle;
    public float grade;
    public GameObject target;
    public bool isAtacking;
    public Rango range;
    public GameObject[] hit;
    public int hit_Select;
    public float speed;

    public bool moreSpeed;
    ///////////////////////////////   Lanzallamas
    public bool isFlamethrowing;
    public List<GameObject> pool= new List<GameObject>();
    public GameObject flamethrower;
    public GameObject head;
    private float timerFire;

    ///////////////////////////////   FireBall
    public GameObject fireBall;
    public GameObject point;
    public List<GameObject> pool2 = new List<GameObject>();
    /////////////
    public int fase = 0;
    public float HP_Min;
    public float HP_Max;
    public AudioSource music;
    public bool dead;
    public Image hpBar;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("Player");
        moreSpeed = false;
    }

    public void bossIA(){
        // Debug.Log("La distancia es: " + Vector3.Distance(transform.position, target.transform.position));
        if (Vector3.Distance(transform.position, target.transform.position) <30){
            //Debug.Log("Se cumple el if de bosIA");
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            point.transform.LookAt(target.transform.position);
            music.enabled = true;
            if(Vector3.Distance(transform.position, target.transform.position) > 1 && !isAtacking){
                //Debug.Log("el valor de rutina es: " + rutina);
                switch(rutina)
                {
                    case 0:  ///Walk
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        animator.SetBool("walk", true);
                        animator.SetBool("run", false);
                        //if(transform.rotation == rotation) transform.Translate(Vector3.forward * speed * Time.deltaTime);
                        transform.Translate(Vector3.forward * speed * Time.deltaTime);
                        animator.SetBool("atack", false);
                        timer += 1 * Time.deltaTime;
                        if(timer > tiempo_rutina){
                            rutina = Random.Range(0, 4);
                            timer = 0;
                        } 
                    break;
                    case 1: //Run
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        animator.SetBool("walk", false);
                        animator.SetBool("run", true);
                        //if(transform.rotation == rotation) transform.Translate(Vector3.forward * speed*2 * Time.deltaTime);
                        transform.Translate(Vector3.forward * speed*2 * Time.deltaTime);
                        animator.SetBool("atack", false);
                    break;
                    case 2: //Lanzallamas
                        animator.SetBool("walk", false);
                        animator.SetBool("run", false);
                        animator.SetBool("atack", true);
                        animator.SetFloat("skills", 0.5f);
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        range.GetComponent<CapsuleCollider>().enabled = false;
                    break;
                    case 3: //Fiireball
                        if(fase == 1){
                            animator.SetBool("walk", false);
                            animator.SetBool("run", false);
                            animator.SetBool("atack", true);
                            animator.SetFloat("skills", 0.75f);
                            range.GetComponent<CapsuleCollider>().enabled = false;
                            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 0.4f);
                        }
                        else{
                            rutina = 0;
                            timer = 0;
                        }
                    break;

                }
            }
        }
    }

    

    public void FinalAnimation(){
        rutina = 0;
        animator.SetBool("atack", false);
        isAtacking = false;
        range.GetComponent<CapsuleCollider>().enabled = true;
        isFlamethrowing = false;
    }

    public void WeaponColliderTrue(){
        hit[hit_Select].GetComponent<SphereCollider>().enabled = true;
    }

    public void WeaponColliderFalse(){
        hit[hit_Select].GetComponent<SphereCollider>().enabled = false;
    }

    public GameObject GetFlamethower(){
        for (int i = 0; i < pool.Count; ++i){
            if (!pool[i].activeInHierarchy){
                pool[i].SetActive(true);
                return pool[i];
            }
        }
        GameObject obj = Instantiate(flamethrower, head.transform.position, head.transform.rotation) as GameObject;
        pool.Add(obj);
        return obj;
    }

    public void FlamethrowerSkill(){
        timerFire += 1 * Time.deltaTime;
        if(timerFire > 0.1f){
            GameObject obj = GetFlamethower();
            obj.transform.position = head.transform.position;
            obj.transform.rotation = head.transform.rotation;
            timerFire = 0;
        }
    }

    public void StartFlamethrower(){
        isFlamethrowing = true;
    }

    public void StopFlamethrower(){
        isFlamethrowing = false;
    }

    public GameObject GetFireBall(){
        for (int i = 0; i < pool2.Count; ++i){
            if (!pool2[i].activeInHierarchy){
                pool2[i].SetActive(true);
                return pool2[i];
            }
        }
        GameObject obj = Instantiate(fireBall, point.transform.position, point.transform.rotation) as GameObject;
        pool2.Add(obj);
        return obj;
    }

    public void FireBallSkill(){
        GameObject obj = GetFireBall();
        obj.transform.position = point.transform.position;
        obj.transform.rotation = point.transform.rotation;
    }


    public void Alive(){
        //
        if (HP_Min < 666){
            fase = 1;
            tiempo_rutina = 1;
        }
        if (HP_Min < 333){
            fase = 2;
            tiempo_rutina = 0.75f;
            if (!moreSpeed){
                moreSpeed = true;
                speed = speed * 1.25f;
            }
        }
        bossIA();
        if(isFlamethrowing){
            FlamethrowerSkill();
        }
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.fillAmount = HP_Min / HP_Max;
        if (HP_Min > 0) Alive();
        else{
            if(!dead){
                animator.SetTrigger("dead");
                music.enabled = false;
                dead = true;
            }
        }
        
    }
}
