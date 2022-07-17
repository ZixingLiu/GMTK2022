using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class Boss : MonoBehaviour
{
    Monster monster;
    public string LoadVictoryScene; 
    private void OnDestroy()
    {
    }
    private void Awake()
    {
        monster = GetComponent<Monster>();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if(monster.currentHealth <=0)
        {
            SceneManager.LoadScene(LoadVictoryScene);

        }
    }
}
