using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToZone2 : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private bool isPlayerInRange;
    Vector3 angleVectorPlayer;
    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")){
            isPlayerInRange = true;
            SceneManager.LoadScene(2);
        }
    }

 void OnSceneLoaded(Scene scene, LoadSceneMode mode)
 {
    angleVectorPlayer.Set(0.0f, 90.0f, 0.0f);
    player.transform.eulerAngles = angleVectorPlayer;
 }

}
