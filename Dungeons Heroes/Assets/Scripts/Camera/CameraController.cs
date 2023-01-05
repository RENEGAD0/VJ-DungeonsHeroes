using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;

    public Animator animator;
    

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void checkCameraFromPlayerLocation(float x, float y, float z){
        //Agrupación de zonas 1
        if (z > 173){
            if(x > 54.5){
                if (z < 208.5f && z > 191.5f){
                    //Debug.Log("Entro a Zone3");
                    animator.SetBool("Zone4", false);
                    animator.SetBool("Zone2", false);
                    animator.SetBool("Zone3", true);
                }
                else if (z < 191.5f && z > 174 ){
                    //Debug.Log("Entro a Zone4");
                    animator.SetBool("Zone3", false);
                    animator.SetBool("Zone4", true);
                }
            }
            if(x < 54.5 && x > 33.5){
                if (z < 207.5f && z > 191.5f){
                    //Debug.Log("Entro a Zone2");
                    animator.SetBool("Zone1", false);
                    animator.SetBool("Zone3", false);
                    animator.SetBool("Zone6", false);
                    animator.SetBool("Zone5", false);
                    animator.SetBool("Zone2", true);
                }
                else if (z > 207.5f){
                    //Debug.Log("Entro a Zone1");
                    animator.SetBool("Zone2", false);
                    animator.SetBool("Zone1", true);
                }
                else if (z < 190.5f && z > 174){
                    //Debug.Log("Entro a Zone6");
                    animator.SetBool("Zone2", false);
                    animator.SetBool("Zona7", false);
                    animator.SetBool("Zone6", true);
                }
            }
            else if ( x < 33.5){
                    //Debug.Log("Entro a Zone5");
                    animator.SetBool("Zone2", false);
                    animator.SetBool("Zone5", true);

            }
        }
        //Agrupación de zonas 3
        else if (z < 142 ){
            if(z < 125.5 && z > 109){
                if (x > 54.5){
                    //Debug.Log("Entro a Zona14");
                    animator.SetBool("Zona13", false);
                    animator.SetBool("Zona14", true);
                }
                else if (x < 33.5){
                    //Debug.Log("Entro a Zona15");
                    animator.SetBool("Zona13", false);
                    animator.SetBool("Zona15", true);
                }
                else {
                    //Debug.Log("Entro a Zona13");
                    animator.SetBool("Zona12", false);
                    animator.SetBool("Zona14", false);
                    animator.SetBool("Zona15", false);
                    animator.SetBool("Zona13", true);                    
                }
            }
            else if (z > 125.5){
                //Debug.Log("Entro a Zona12");
                animator.SetBool("Zona7", false);
                animator.SetBool("Zona13", false);
                animator.SetBool("Zona12", true);
            }
            else{
                //Debug.Log("Entro a Zona16");
                animator.SetBool("Zona13", false);
                animator.SetBool("Zona16", true);
            }
            
        }
        //Agrupación de zonas 2
        else{
            if (x > 50){
                if (z > 158.6f){
                    //Debug.Log("Entro a Zona8");
                    animator.SetBool("Zona7", false);
                    animator.SetBool("Zona8", true);
                }
                else{
                    //Debug.Log("Entro a Zona10");
                    animator.SetBool("Zona7", false);
                    animator.SetBool("Zona10", true);
                }
            }
            else if ( x < 38){
                if (z > 158.6f){
                    //Debug.Log("Entro a Zona9");
                    animator.SetBool("Zona7", false);
                    animator.SetBool("Zona9", true);
                }
                else{
                    //Debug.Log("Entro a Zona11");
                    animator.SetBool("Zona7", false);
                    animator.SetBool("Zona11", true);
                }

            }
            else{
                //Debug.Log("Entro a Zona7");
                animator.SetBool("Zone6", false);
                animator.SetBool("Zona8", false);
                animator.SetBool("Zona9", false);
                animator.SetBool("Zona10", false);
                animator.SetBool("Zona11", false);
                animator.SetBool("Zona12", false);
                animator.SetBool("Zona7", true);
            }
        }
    }

    // Update is called once per frame
    void Update(){
        checkCameraFromPlayerLocation(player.position.x, player.position.y, player.position.z);
    }
}
