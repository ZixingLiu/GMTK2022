using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerControlTest : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;

    public Vector2 minPower;
    public Vector2 maxPower;

    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    Vector3 lastVelocity;

    TrajectoryLine tl;

    public bool canDrag = true;

    

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        //currentHealth = maxHealth;

    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tl = GetComponent<TrajectoryLine>();
    }

    // Update is called once per frame
    void Update()
    {
        //debug
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            //currentHealth += 10;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            //currentHealth -= 10;
        }

        // health

        //if (currentHealth > maxHealth)
        //{
        //    currentHealth = maxHealth;
        //}
        //if (currentHealth <= 0)
        //{
        //    currentHealth = 0;
        //    Debug.Log("die");
        //}
        //healthText.text = currentHealth + "/" + maxHealth;

        //lerpSpeed = 3f * Time.deltaTime;

        //HealthBarFiller();
        //ColorChanger();

        //movement
        if (rb.velocity.magnitude <= 1f)
        {
            canDrag = true;
            rb.velocity = Vector2.zero;
        }
        else
        {
            canDrag = false;
        }

        lastVelocity = rb.velocity;

    }
    //void HealthBarFiller()
    //{
    //    healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currentHealth / maxHealth, lerpSpeed);
    //}

    //void ColorChanger()
    //{
    //    Color healthColor = Color.Lerp(noHealthColor, fullHealthColor, (currentHealth / maxHealth));

    //    healthBar.color = healthColor;
    //}

    private void OnMouseDown()
    {
        if(canDrag)
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15f;
            //Debug.Log(startPoint);
        }

    }
    private void OnMouseDrag()
    {
        if(canDrag)
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15f;

            tl.RenderLine(startPoint, currentPoint);
        }
        
    }
    private void OnMouseUp()
    {
        if(canDrag)
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15f;

            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x),
                Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));

            rb.AddForce(force * power, ForceMode2D.Impulse);
            tl.EndLine();
        }
        

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        float speed = lastVelocity.magnitude;
        Vector3 direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
    }
}
