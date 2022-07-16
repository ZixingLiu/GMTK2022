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


    private void Awake()
    {
        diceSidesHolder = GameObject.Find("Dice holder");
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
        StartCoroutine(RollTheDice());
        rollButton.SetActive(false);
        attackButton.SetActive(true);
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

            yield return new WaitForSeconds(0.05f);
            diceDisplay = CurrentDiceDisplay;
        }
        finalSide = randomDiceSide + 1;
        Debug.Log(finalSide);
    }

  
}
