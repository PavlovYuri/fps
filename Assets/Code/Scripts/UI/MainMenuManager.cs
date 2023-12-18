using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsPanel;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Debug.Log("Game is closed!");
        Application.Quit();
    }

    public void Settings()
    {
        mainMenu.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void Back()
    {
        settingsPanel.SetActive(false);
        mainMenu.SetActive(true);
    }
}
