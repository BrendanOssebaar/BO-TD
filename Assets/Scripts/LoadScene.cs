using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void quit(string sceneName)
    {
        Application.Quit();
    }
    public void startgame(string sceneName)
    {
        SceneManager.LoadScene(1);
    }
}
