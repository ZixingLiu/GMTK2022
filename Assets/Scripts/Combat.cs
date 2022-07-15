using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{

    public GameObject combatCnavas;

    public RollDice rd;

    PlayerControl playerControl;

    private void Awake()
    {
        //rd = FindObjectOfType<RollDice>();
        playerControl = GetComponent<PlayerControl>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            //stop movement
            playerControl.rb.velocity = Vector3.zero;
            playerControl.canDrag = false;

            //enter combat
            combatCnavas.SetActive(true);
            rd.rollButton.SetActive(true);
            rd.attackButton.SetActive(false);
            Debug.Log("enter combat");

        }
    }
}
