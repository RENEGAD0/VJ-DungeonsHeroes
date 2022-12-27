using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundBetweenScenes : MonoBehaviour
{

    private SoundBetweenScenes instance;
    public SoundBetweenScenes   Instance{
        get{
            return instance;
        }
    }

    private void Awake(){

        if(FindObjectsOfType(GetType()).Length > 1){
            Destroy(gameObject);
        }
        if(instance != null && instance != this){
            Destroy(gameObject);
            return;
        }
        else{
            instance = this;
        }
        int scene = SceneManager.GetActiveScene().buildIndex;
        if (scene == 0 || scene == 4 || scene == 5){
            DontDestroyOnLoad(gameObject);
        }
    }



}
