using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToZone1 : MonoBehaviour
{
    private bool isPlayerInRange;
    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")){
            isPlayerInRange = true;
            SceneManager.LoadScene(1);
        }
    }
}
