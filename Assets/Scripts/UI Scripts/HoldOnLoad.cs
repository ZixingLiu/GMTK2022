using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoldOnLoad : MonoBehaviour
{
    public void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("StartAudio");
        if (objs.Length > 1 || scene.name == "GameScene")
        {
            Destroy(this.gameObject);
        }
        GameObject[] objects = GameObject.FindGameObjectsWithTag("GameAudio");
        if (objs.Length > 1 || scene.name == "FailScene" || scene.name == "VictoryScene")
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);


    }
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("StartAudio");
        if (objs.Length > 1 || scene.name == "GameScene")
        {
            Destroy(this.gameObject);
        }
        GameObject[] objects = GameObject.FindGameObjectsWithTag("GameAudio");
        if (objs.Length > 1 || scene.name == "FailScene" || scene.name == "VictoryScene")
        {
            Destroy(this.gameObject);
        }
    }
}
