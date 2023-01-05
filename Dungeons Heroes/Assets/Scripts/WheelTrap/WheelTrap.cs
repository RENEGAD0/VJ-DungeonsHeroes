using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelTrap : MonoBehaviour
{

    public AnimationsPlayer playerScript;

    void OnTriggerEnter(Collider collid)
    {
        if (collid.name == "Player" && !playerScript.invencible)
        {
            playerScript.HP_Min -= 10;
            
                playerScript.animator.Play("hurt");
                playerScript.audioSourceHurt.PlayOneShot(playerScript.hurt_sound, 0.3F);
                Vector3 forceDirection = Vector3.forward;
                float forceMagnitude = 600.0f;
                // rigidbody.velocity = forceDirection;
                playerScript.rigidbody.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
            
        }
    }
        // Start is called before the first frame update
        void Start()
    {
        GameObject target = GameObject.Find("Player");
        playerScript = target.GetComponent<AnimationsPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
