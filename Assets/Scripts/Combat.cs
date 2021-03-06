using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{
    public int playerDamage;
    public int playerShield;

    public GameObject combatCnavas;


    public RollDice rd;

    PlayerControl playerControl;
    DoTweenManager dotween;
    GameObject targetMonster;
    public GameObject targetTreasure;

    GameObject canvas;
    GameObject rewardInScene;

    AudioSource audiosource;
    public AudioClip monsterHitSound;
     

    Animator fightAnimator;

    private void Awake()
    {
        //rd = FindObjectOfType<RollDice>();
        playerControl = GetComponent<PlayerControl>();
        dotween = GetComponent<DoTweenManager>();
        canvas = GameObject.Find("Canvas");
        rewardInScene = GameObject.Find("Reward in Scene");

        fightAnimator = GameObject.Find("fight animation").GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerControl.shieldCount = playerShield;
        if(targetMonster == null)
        {
            playerShield = 0;
        }
    }

    public void ClickAttacck()
    {
        StartCoroutine(AttackAnim());
        rd.attackButton.GetComponent<Button>().interactable = false;
    }

    public IEnumerator AttackAnim()
    {
        //hit monster sound
        GetComponent<AudioSource>().clip = monsterHitSound;
        GetComponent<AudioSource>().Play();
        dotween.targetPos = targetMonster.transform.position;
        dotween.PlayAnimatetion();

        Monster monster = targetMonster.GetComponent<Monster>();
        monster.currentHealth -= playerDamage;
        
        if(playerShield <=0)
        {
            monster.attack();
        }
        else if(playerShield < monster.damage)
        {
            playerControl.currentHealth -= monster.damage - playerShield;
            playerShield = 0;
            
        }
        else
        {
            playerShield -= monster.damage;
        }


        yield return new WaitForSeconds(1f);

        rd.rollButton.SetActive(true);
        rd.attackButton.GetComponent<Button>().interactable = true;
        rd.attackButton.SetActive(false);

    }

    public void Getshield(int shieldNum)
    {

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            fightAnimator.SetTrigger("fight");
            targetMonster = collision.gameObject;
            //stop movement
            playerControl.rb.velocity = playerControl.rb.velocity * 0.05f;
            playerControl.canDrag = false;
            playerControl.inCombat = true;

            //enter combat
            combatCnavas.SetActive(true);
            rd.rollButton.SetActive(true);
            rd.attackButton.SetActive(false);
            //Debug.Log("enter combat");

        }

        if(collision.tag == "Treasure")
        {
            targetTreasure = collision.gameObject;
            //stop movement
            playerControl.rb.velocity = playerControl.rb.velocity * 0.05f;
            playerControl.canDrag = false;
            playerControl.inCombat = true;

            //playerControl.rb.velocity = playerControl.rb.velocity * 0.05f;
            playerControl.canDrag = false;
            playerControl.inCombat = true;

            //move treasure canvas to target pos
            Treasure treasure = collision.gameObject.GetComponent<Treasure>();
            treasure.treasureCanvas.SetActive(true);
            treasure.treasureCanvas.transform.SetParent(canvas.transform);
            treasure.treasureCanvas.transform.position = rewardInScene.transform.position;
            treasure.treasureCanvas.transform.localScale = Vector3.one;
            treasure.treasureCanvas.transform.SetSiblingIndex(1);
        }
    }
}
