using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollDice : MonoBehaviour
{
    public GameObject[] diceSides;

    public GameObject diceSidesHolder;

    public GameObject diceDisplay;

    public GameObject rollButton;
    public GameObject attackButton;
    Combat combat;

    AudioSource audioSource;
    public AudioClip diceRoll;


    private void Awake()
    {
        diceSidesHolder = GameObject.Find("Dice holder");
        combat = FindObjectOfType<Combat>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Roll()
    {
        // àâàâÉù Ò¡÷»×Ó
        GetComponent<AudioSource>().clip = diceRoll;
        GetComponent<AudioSource>().Play();
        StartCoroutine(RollTheDice());
        rollButton.SetActive(false);
        attackButton.SetActive(true);
        attackButton.GetComponent<Button>().interactable = false;
    }

    public IEnumerator RollTheDice()
    {

        int randomDiceSide = 0;

        int finalSide = 0;

        for(int i=0; i <= 20;i++)
        {
            randomDiceSide = Random.Range(0, 6);

            Destroy(diceDisplay);
            GameObject CurrentDiceDisplay = Instantiate(diceSides[randomDiceSide],transform.position,Quaternion.identity,transform);
            
            CurrentDiceDisplay.GetComponent<Image>().SetNativeSize();
            CurrentDiceDisplay.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 200);

            yield return new WaitForSeconds(0.05f);
            diceDisplay = CurrentDiceDisplay;
        }

        combat.playerDamage = diceSides[randomDiceSide].GetComponent<DiceSide>().damage;
        combat.playerShield += diceSides[randomDiceSide].GetComponent<DiceSide>().shield;
        finalSide = randomDiceSide + 1;
        //Debug.Log(finalSide);
        attackButton.GetComponent<Button>().interactable = true;



    }


}
