using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordCollider : MonoBehaviour
{
    private Collider swordColl;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Floor")
        {

            UnityEngine.Debug.Log(collisionInfo);
        }
        else if (collisionInfo.collider.tag == "Obstacle")
        {
            swordColl.isTrigger = true;
            UnityEngine.Debug.Log("AAAAAAAAAAAAAAAAAAAAAAA");
        }
        else if (collisionInfo.collider.tag == "Enemy")
        {
            swordColl.isTrigger = false;
            UnityEngine.Debug.Log(collisionInfo);
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
       
    }

    void OnCollisionExit(Collision collisionInfo)
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject sword = GameObject.Find("sword");
        swordColl = sword.GetComponent<Collider>();
    }

}
