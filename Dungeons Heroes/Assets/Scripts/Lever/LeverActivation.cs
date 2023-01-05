using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverActivation : MonoBehaviour
{

    private bool isPlayerInRange;

    [SerializeField] private GameObject ChestAparition;

    [SerializeField] private GameObject DeleteDoor;

    [SerializeField] private CanvasManager canvas;

    public Animator animator;

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")){
            isPlayerInRange = true;
            Debug.Log("Player en rango = true");
        }
    }

    private void OnTriggerExit(Collider collision) {
        if (collision.gameObject.CompareTag("Player")){
            isPlayerInRange = false;
            Debug.Log("Player en rango = false");
        }
    }
    
        // Start is called before the first frame update
    void Start()
    {
     animator = GetComponent<Animator>();
     
    }

    void getKey(){
        canvas.getHUDKEY();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInRange == true && Input.GetKeyDown(KeyCode.I)){
            animator.SetTrigger("Actived");
            animator.SetBool("run", false);
            ChestAparition.SetActive(true);
            DeleteDoor.SetActive(false);
            Invoke("getKey", 6f);
        }
        
    }
}