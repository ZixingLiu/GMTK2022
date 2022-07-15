using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollDice : MonoBehaviour
{
    public GameObject[] diceSides;

    public GameObject diceSidesHolder;

    public GameObject diceDisplay;

    private void Awake()
    {
        diceSidesHolder = GameObject.Find("Dice holder");
    }

    // Start is called before the first frame update
    void Start()
    {
        //for(int i=0;i < diceSidesHolder.transform.childCount;i++)
        //{
        //    diceSides[i] = diceSidesHolder.transform.GetChild(i).gameObject;
        //}
        //diceDisplay = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        StartCoroutine(RollTheDice());
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
