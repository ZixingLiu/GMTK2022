using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeSrpite : MonoBehaviour
{

    public Sprite[] sprite;
    public Sprite normalSprite;


    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
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
        if(rb.velocity.magnitude >0.2f)
        {
            StartCoroutine(ChangeSprite());
        }
        else
        {
            StopCoroutine(ChangeSprite());
            spriteRenderer.sprite = normalSprite;
        }
        
    }

    public IEnumerator ChangeSprite()
    {

        int randomDiceSide = 0;

        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, sprite.Length);

            spriteRenderer.sprite = sprite[randomDiceSide];

            yield return new WaitForSeconds(0.3f);
        }
    }
}
