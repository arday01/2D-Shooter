using UnityEngine.SceneManagement;
using UnityEngine;

using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;
    
    public static Vector2 lastCheckPointPos = new Vector2(-3,0);

    public static int numberOfCoins;
    

    
   
   

    public static void ResetPosition()
    {
        lastCheckPointPos = new Vector2(-3, 0);

    }

    private void Awake()
    {
        isGameOver = false;
    }
    

    void Update()
    {
        
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    
}
