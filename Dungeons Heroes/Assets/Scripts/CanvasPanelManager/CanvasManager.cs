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

    [SerializeField] private GameObject ExtraWeaponPanel;

    [SerializeField] private GameObject Key1Panel;

    [SerializeField] private GameObject Key2Panel;

    [SerializeField] private GameObject BossKeyPanel;

    [SerializeField] private GameObject DieSound;

    [SerializeField] private GameObject VicotorySound;

    private bool key1;

    private bool key2;

    private bool bosskey;

    private bool idpaused;


    public void Pause(){
        idpaused = true;
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void getHUDKEY(){
        if (!key1 && !key2 && !bosskey){
            getKey1();
        }
        else if (key1 && !key2){
            getKey2();
        }
        else if (key1 && key2 && !bosskey){
            getBossKey();
        }
    }    

    public void getKey1(){
        Key1Panel.SetActive(true);
        key1 = true;
    }
    public void getKey2(){
        Key2Panel.SetActive(true);
        key2 = true;
    }

    public void getBossKey(){
        BossKeyPanel.SetActive(true);
        bosskey = true;
    }

    public void Die(){
        DiePanel.SetActive(true);
        DieSound.SetActive(true);
    }

    public void BossFight(){
        BossHP.SetActive(true);
    }

    public void Win(){
        WinPanel.SetActive(true);
        VicotorySound.SetActive(true);
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

    public void ExtraWeapon(){
        ExtraWeaponPanel.SetActive(true);
    }


    // Start is called before the first frame update
    void Start()
    {
        idpaused = false;
        key1 = false;
        key2 = false;
        bosskey = false;
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
