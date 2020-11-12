using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public string sceneName;
    public string sceneName2;

    bool isPauseOn = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPauseOn)
            {
                OnPauseMenu();
            }
            else
            {
                OffPauseMenu();
            }

        }
    }

    public void OnPauseMenu()
    {
        isPauseOn = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void OffPauseMenu()
    {
        isPauseOn = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }


    public void LoadScene1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName2);
    }
}
