using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public int playerDamage;
    public int playerShield;

    public GameObject combatCnavas;

    public RollDice rd;

    PlayerControl playerControl;
    DoTweenManager dotween;
    GameObject targetMonster;

    private void Awake()
    {
        //rd = FindObjectOfType<RollDice>();
        playerControl = GetComponent<PlayerControl>();
        dotween = GetComponent<DoTweenManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickAttacck()
    {
        StartCoroutine(AttackAnim());
    }

    public IEnumerator AttackAnim()
    {
        dotween.targetPos = targetMonster.transform.position;
        dotween.PlayAnimatetion();

        Monster monster = targetMonster.GetComponent<Monster>();
        monster.currentHealth -= playerDamage;
        
        monster.attack();


        yield return new WaitForSeconds(1f);

        rd.rollButton.SetActive(true);
        rd.attackButton.SetActive(false);

    }

    public void Getshield(int shieldNum)
    {

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            targetMonster = collision.gameObject;
            //stop movement
            playerControl.rb.velocity = playerControl.rb.velocity * 0.05f;
            playerControl.canDrag = false;
            playerControl.inCombat = true;

            //enter combat
            combatCnavas.SetActive(true);
            rd.rollButton.SetActive(true);
            rd.attackButton.SetActive(false);
            Debug.Log("enter combat");

        }
    }
}
