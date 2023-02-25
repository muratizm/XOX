using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public static bool levelDone = false;
    public static bool levelWon = false;
    [SerializeField] GameObject resumeButton;
    [SerializeField] GameObject nextLevelButton;
    [SerializeField] GameObject currentLevelButton;
    [SerializeField] GameObject winText;
    [SerializeField] GameObject loseText;
    private Cannon cannon;

    private void Start()
    {
        cannon = FindObjectOfType<Cannon>();
        Time.timeScale = 1;
    }

    public void Pause ()
    {
        if (levelDone)
        {
            if (levelWon)
            {
                winText.SetActive(true);
                nextLevelButton.SetActive(true);
            }
            else
            {
                loseText.SetActive(true);
                currentLevelButton.SetActive(true);
            }
            resumeButton.SetActive(false);
        }
        else
        {
            resumeButton.SetActive(true);
            nextLevelButton.SetActive(false);
        }
        cannon.enabled = false;
        Time.timeScale = 0;
        GameIsPaused = true;
        pauseMenuUI.SetActive(true);
    }

    public void Resume ()
    {
        cannon.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void PauseButton()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void LoadMenu()
    {
        Debug.Log("loading menu...");
    }
    public void OpenLevel(string _levelName)
    {
        SceneManager.LoadScene(_levelName);
    }
    public void OpenNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OpenCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
