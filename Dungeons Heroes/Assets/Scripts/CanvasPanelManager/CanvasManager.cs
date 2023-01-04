using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{

    [SerializeField] private GameObject PausePanel;

    [SerializeField] private GameObject BossHP;

    [SerializeField] private GameObject WinPanel;

    [SerializeField] private GameObject DiePanel;

    private bool idpaused;


    public void Pause(){
        idpaused = true;
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Die(){
        DiePanel.SetActive(true);
    }

    public void BossFight(){
        BossHP.SetActive(true);
    }

    public void Win(){
        WinPanel.SetActive(true);
    }

    public void RestartPause(){
        PausePanel.SetActive(false);
        idpaused = false;
        Time.timeScale = 1f;
        
    }

    public void GotoStartMenu(){
        SceneManager.LoadScene(0);
    }

    public void GotoCredits(){
        SceneManager.LoadScene(3);
    }

    public void ReloadScene(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    // Start is called before the first frame update
    void Start()
    {
        idpaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(idpaused)RestartPause();
            else Pause();
        }
    }
}
