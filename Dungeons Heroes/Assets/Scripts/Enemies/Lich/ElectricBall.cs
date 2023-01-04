using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBall : MonoBehaviour
{
    public AnimationsPlayer playerScript;

    void OnTriggerEnter(Collider collid)
    {
        if (collid.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
        else if (collid.name == "Player" && !playerScript.invencible)
        {
            playerScript.HP_Min -= 20;
            if (playerScript.dead == false)
            {
                playerScript.animator.Play("hurt");
                Vector3 forceDirection = transform.forward;
                float forceMagnitude = 600.0f;
                // rigidbody.velocity = forceDirection;
                playerScript.rigidbody.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
                Destroy(gameObject);
            }
        }
        else if(collid.name == "sword")
        {
            Destroy(gameObject);
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
