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
                if (z > 208.5f && z > 191.5f){
                    Debug.Log("Entro a Zone3");
                    animator.SetBool("Zone4", false);
                    animator.SetBool("Zone2", false);
                    animator.SetBool("Zone3", true);
                }
                else if (z < 191.5f && z > 174 ){
                    Debug.Log("Entro a Zone4");
                    animator.SetBool("Zone3", false);
                    animator.SetBool("Zone4", true);
                }
            }
            if(x < 54.5 && x > 33.5){
                if (z < 208.5f && z > 191.5f){
                    Debug.Log("Entro a Zone2");
                    animator.SetBool("Zone1", false);
                    animator.SetBool("Zone3", false);
                    animator.SetBool("Zone6", false);
                    animator.SetBool("Zone5", false);
                    animator.SetBool("Zone2", true);
                }
                else if (z > 208.5f){
                    Debug.Log("Entro a Zone1");
                    animator.SetBool("Zone2", false);
                    animator.SetBool("Zone1", true);
                }
                else if (z < 191.5f && z > 174){
                    Debug.Log("Entro a Zone4");
                    animator.SetBool("Zone2", false);
                    animator.SetBool("Zone7", false);
                    animator.SetBool("Zone4", true);
                }

            }
        }
        //Agrupación de zonas 3
        else if (z < 142 ){
            if(z < 126 && z > 108){
                if (x > 54.5){
                    Debug.Log("Entro a Zone14");
                    animator.SetBool("Zone13", false);
                    animator.SetBool("Zone14", true);
                }
                else if (x < 33.5){
                    Debug.Log("Entro a Zone15");
                    animator.SetBool("Zone13", false);
                    animator.SetBool("Zone15", true);
                }
                else {
                    Debug.Log("Entro a Zone13");
                    animator.SetBool("Zone12", false);
                    animator.SetBool("Zone14", false);
                    animator.SetBool("Zone15", false);
                    animator.SetBool("Zone15", true);                    
                }
            }
            else if (z > 126){
                Debug.Log("Entro a Zone12");
                animator.SetBool("Zone7", false);
                animator.SetBool("Zone13", false);
                animator.SetBool("Zone12", true);
            }
            else{
                Debug.Log("Entro a Zone16");
                animator.SetBool("Zone13", false);
                animator.SetBool("Zone16", true);
            }
            
        }
        //Agrupación de zonas 2
        else{
            if (x > 51){
                if (z > 158.6f){
                    Debug.Log("Entro a Zone8");
                    animator.SetBool("Zone7", false);
                    animator.SetBool("Zone8", true);
                }
                else{
                    Debug.Log("Entro a Zone10");
                    animator.SetBool("Zone7", false);
                    animator.SetBool("Zone10", true);
                }
            }
            else if ( x < 38){
                if (z > 158.6f){
                    Debug.Log("Entro a Zone9");
                    animator.SetBool("Zone7", false);
                    animator.SetBool("Zone9", true);
                }
                else{
                    Debug.Log("Entro a Zone11");
                    animator.SetBool("Zone7", false);
                    animator.SetBool("Zone11", true);
                }

            }
            else{
                Debug.Log("Entro a Zone7");
                animator.SetBool("Zone6", false);
                animator.SetBool("Zone8", false);
                animator.SetBool("Zone9", false);
                animator.SetBool("Zone10", false);
                animator.SetBool("Zone11", false);
                animator.SetBool("Zone12", false);
                animator.SetBool("Zone7", true);
            }
        }
    }

    // Update is called once per frame
    void Update(){
        checkCameraFromPlayerLocation(player.position.x, player.position.y, player.position.z);
    }
}
