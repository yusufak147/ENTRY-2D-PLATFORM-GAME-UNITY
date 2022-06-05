using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject gameOverMenu;

    void OnEnable()
    {
        PlayerManager.OnPlayerDeath += EnableGameOverMenu;
     
    }
    private void OnDisable()
    {
        PlayerManager.OnPlayerDeath -= EnableGameOverMenu;
        
    }


        public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("pizzadario");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
