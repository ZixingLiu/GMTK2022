using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeSrpite : MonoBehaviour
{

    public Sprite[] sprite;
    public Sprite normalSprite;

    public bool canChangeSprite = false;


    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;

    //AudioSource audioSource;
    //public AudioClip diceMovementSound; 
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.magnitude >1f)
        {
            canChangeSprite = true;
            StartCoroutine(ChangeSprite());
        }
        else
        {
            canChangeSprite = false;
            StopCoroutine(ChangeSprite());
            spriteRenderer.sprite = normalSprite;
            //GetComponent<AudioSource>().clip = diceMovementSound; 
            //GetComponent<AudioSource>().Play();
        }
        
    }

    public IEnumerator ChangeSprite()
    {

        int randomDiceSide = 0;

        while(canChangeSprite)
        {
            randomDiceSide = Random.Range(0, sprite.Length);

            spriteRenderer.sprite = sprite[randomDiceSide];
            //int randomSide = 

            yield return new WaitForSeconds(1.2f);

        }
        
    }
}
