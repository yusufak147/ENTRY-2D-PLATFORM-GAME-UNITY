using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{

    public GameObject gameOverMenu;

    void OnEnable()
    {
       
        boos2.OnEnemyDeath += EnableGameOverMenu;
    }
    private void OnDisable()
    {
      
        boos2.OnEnemyDeath += EnableGameOverMenu;
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
