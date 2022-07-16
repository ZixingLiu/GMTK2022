using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class Boss : MonoBehaviour
{
    public string LoadVictoryScene; 
    private void OnDestroy()
    {
        SceneManager.LoadScene(LoadVictoryScene);
    }

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
