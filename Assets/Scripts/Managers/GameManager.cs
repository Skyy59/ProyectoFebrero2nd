using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int lives = 5;
    [SerializeField] private GameObject gameOverIU;
    [SerializeField] private GameObject winningIU;

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
        gameOverIU.SetActive(true);
    }

    public void Winning()
    {
        Time.timeScale = 0f;
        winningIU.SetActive(true);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
