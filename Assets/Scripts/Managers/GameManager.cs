using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int lives = 5;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject winningUI;
    [SerializeField] private GameObject pauseUI;

    private void Awake()
    {
        Instance = this;
    }

    public void LoseLife()
    {
        lives--;

        if (lives <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }

    public void Winning()
    {
        Time.timeScale = 0f;
        winningUI.SetActive(true);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void PauseMenu()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
    }
}
