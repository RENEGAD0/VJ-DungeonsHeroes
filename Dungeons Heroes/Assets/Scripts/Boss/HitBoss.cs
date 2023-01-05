using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoss : MonoBehaviour
{

    public int damage;

    public string kindOfDamage;
    public GameObject target;
    public AnimationsPlayer playerScript;


    void OnTriggerEnter(Collider coll) {
        Debug.Log("el daño es" + kindOfDamage);
        if(coll.CompareTag("Player") && playerScript.HP_Min > 0){
            if(kindOfDamage != "fire"){
                playerScript.animator.Play("hurt");
                Vector3 forceDirection = transform.forward;
                float forceMagnitude = 600.0f;
                playerScript.rigidbody.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
            }
            playerScript.audioSourceHurt.PlayOneShot(playerScript.hurt_sound, 0.3F);
            coll.GetComponent<AnimationsPlayer>().HP_Min -= damage;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        playerScript = target.GetComponent<AnimationsPlayer>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
