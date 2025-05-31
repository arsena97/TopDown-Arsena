using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject gameOverUI;
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
   
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadGameOverUI()
    {
        gameUI.SetActive(false);
        gameOverUI.SetActive(true);
    }
  
}
