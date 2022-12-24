using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargoyleMovement : MonoBehaviour
{

    private bool isPlayerInRange;

    [SerializeField] private GameObject rotateSound;


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
            Debug.Log("Deberia girar la gargola");
            transform.Rotate(0, 90, 0);
            rotateSound.SetActive(false);
            rotateSound.SetActive(true);
        }
        
    }
}