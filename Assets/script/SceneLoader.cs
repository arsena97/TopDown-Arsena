using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //lonsolshigamoaq Debug.Log
    // int veriebli
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject gameOverUI;
    public void LandGameScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadGameOverUI()
    {
        gameUI.SetActive(false);
        gameOverUI.SetActive(true);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Restart");
    }

}
