using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame(){ 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }              // play butonu çalışma kodu



    public void QuitGame()      //çıkma butonu çalışma kodu
    {
        Debug.Log("Oyundan çıkıldı.");
        Application.Quit(); 
    }

    public void ReturnToMainMenu() //main menüye dönme butonu
    {
        SceneManager.LoadScene("MainMenu");
    }
}
