using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverActivation : MonoBehaviour
{

    private bool isPlayerInRange;

    [SerializeField] private GameObject ChestAparition;

    [SerializeField] private GameObject DeleteDoor;


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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInRange == true && Input.GetButtonDown("Fire1")){
            ChestAparition.SetActive(true);
            DeleteDoor.SetActive(false);
        }
        
    }
}