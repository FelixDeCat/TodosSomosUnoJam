using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public string sceneName;
    public string sceneName2;

    public void LoadScene1()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene(sceneName2);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
