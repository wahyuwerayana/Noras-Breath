using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    bool isPaused = false;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            isPaused = !isPaused;
            if(isPaused){
                PauseGame();
            } else{
                ResumeGame();
            }
        }
    }

    public void ResumeGame(){
        Time.timeScale = 1;
        pausePanel.gameObject.SetActive(false);
        isPaused = false;
    }

    public void PauseGame(){
        Time.timeScale = 0;
        pausePanel.gameObject.SetActive(true);
        isPaused = true;
    }

    public void LoadMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
