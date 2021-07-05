using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    [SerializeField]
    private GameObject pausePanel, gameOverPanel;
    
    void Awake()
    {
        MakeInstance();
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PauseButton()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeButton()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }


    

    public void RestartButton()
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene("GamePlay");
        Time.timeScale = 1f;
    }
    public void NewGameButton()
    {
        pausePanel.SetActive(false);
        SceneManager.LoadScene("GamePlay");
        Time.timeScale = 1f;
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlaneDiedPanel()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    
}
