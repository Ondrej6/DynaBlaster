using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu2 : MonoBehaviour
{
    /*
     * Skript riadiaci menu
     */

    //spustenie hry
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    //ukončenie hry
    public void QuitGame()
    {
        Application.Quit();
    }
}
