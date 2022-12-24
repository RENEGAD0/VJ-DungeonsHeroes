using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Instructions(){
    SceneManager.LoadScene(4);
    }

    public void Credits(){
    SceneManager.LoadScene(5);
    }
    public void Quit(){
        Debug.Log("Salir...");
        Application.Quit();
    }

    public void GoBack(){
        SceneManager.LoadScene(0);
    }


}