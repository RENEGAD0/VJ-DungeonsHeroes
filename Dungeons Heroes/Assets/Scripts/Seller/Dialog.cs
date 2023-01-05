using System.Collections;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    private bool isPlayerInRange;
    private bool dialogueStart;
    private bool firstdialogue = true;
    private int lineIndex;
    private float dialogueSpeed = 0.04f;

    [SerializeField] private GameObject exclamationMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject healSound;

    [SerializeField, TextArea(4,6)] private string[] dialogueLines;

    [SerializeField] private CanvasManager canvas;

    [SerializeField] private AnimationsPlayer playerController;

    void Update(){
        if(isPlayerInRange == true && Input.GetKeyDown(KeyCode.I) && firstdialogue == true){
            if(!dialogueStart){
            StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex]){
                NextDialogueLine();
            }
            else{
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }

    private void NextDialogueLine(){
        lineIndex++;
        if (lineIndex == 3){
            dialogueSpeed = 0.3f;
        }
        else dialogueSpeed = 0.04f;
        if(lineIndex < dialogueLines.Length){
            StartCoroutine(ShowLine());
        }
        else{
            healSound.SetActive(true);
            playerController.RestartHeal();
            firstdialogue = false;
            dialogueStart = false;
            dialoguePanel.SetActive(false);
            exclamationMark.SetActive(false);
            Time.timeScale = 1f;
            canvas.ExtraWeapon();
        }
    }

    private IEnumerator ShowLine(){
        dialogueText.text = string.Empty;
        foreach(char ch in dialogueLines[lineIndex]){
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(dialogueSpeed);
        }
    }

    private void StartDialogue(){
        dialogueStart = true;
        exclamationMark.SetActive(false);
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
        Time.timeScale = 0f;
    }
    
    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")){
            isPlayerInRange = true;
            Debug.Log("Player en rango = true");
            if(firstdialogue){
            exclamationMark.SetActive(true);
            }
            else{
                firstdialogue= false;
            }
        }

    }
    private void OnTriggerExit(Collider collision) {
        if (collision.gameObject.CompareTag("Player")){
            isPlayerInRange = false;
            Debug.Log("Player en rango = false");
        }
    }
}