using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string LoadStartScene; 
    public void StartScene()
    {
        SceneManager.LoadScene(LoadStartScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
