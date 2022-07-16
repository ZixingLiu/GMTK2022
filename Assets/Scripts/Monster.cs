using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    public int damage;
    public float maxHealth;
    float currentHealth;

    public GameObject Player;
    DoTweenManager doTween;

    public GameObject rewardCanvas;

    private void Awake()
    {
        Player = FindObjectOfType<PlayerControl>().gameObject;
        doTween = GetComponent<DoTweenManager>();   
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            //end fight
            rewardCanvas.SetActive(true);
            //open reward

        }
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
    }

    public void attack()
    {
        doTween.targetPos = Player.transform.position;
        doTween.PlayAnimatetion();
    }
}
