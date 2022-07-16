using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneTransition : MonoBehaviour
{
    public string LoadDialogueScene; 
    public void DialogScene()
    {
        SceneManager.LoadScene(LoadDialogueScene);
    }
    public void QuitGame()
    {
        Debug.Log("Game Quit"); 
        Application.Quit();
    }
}
