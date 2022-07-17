using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; 

public class PlayerControl : MonoBehaviour
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
    public bool inCombat = false;

    [Header("health")]
    public float maxHealth = 100;
    public float currentHealth;
    public Image healthBar;
    public TextMeshProUGUI healthText;
    float lerpSpeed;

    public Color fullHealthColor;
    public Color noHealthColor;

    //shield
    public int shieldCount;
    public GameObject shieldHolder;
    public GameObject shieldIcon;

    AudioSource audioSource;
    public AudioClip stretchSound;
    public AudioClip wallHitSound;
    //public AudioClip diceMovement; 

    //distance boss
    TextMeshProUGUI distanceText;

    public string LoadFailScene;
    GameObject boss;

    public GameObject tutorialText1; 
    public GameObject tutorialText2;
    public GameObject tutorialText3;
    public GameObject tutorialText4;
    public GameObject tutorialText5;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        currentHealth = maxHealth;

    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tl = GetComponent<TrajectoryLine>();
        shieldHolder = GameObject.Find("shield holder");
        distanceText = GameObject.Find("distance text").GetComponent<TextMeshProUGUI>();
        boss = FindObjectOfType<Boss>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(boss != null)
        {
            //calculate distance
            int distance = Mathf.Abs((int)(boss.transform.position - transform.position).magnitude);
            distanceText.text = "Boss Distance: " + distance.ToString() + "M";
        }
        

        //lock rotation
        transform.rotation = Quaternion.identity;

        //shield manage
        if (shieldHolder.transform.childCount < shieldCount)
            Instantiate(shieldIcon, shieldHolder.transform);

        if (shieldHolder.transform.childCount > shieldCount)
            Destroy(shieldHolder.transform.GetChild(0).gameObject);

        // health

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("die");
            //Fail Scene
            SceneManager.LoadScene(LoadFailScene);
        }
        healthText.text = currentHealth + "/" + maxHealth;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();

        //movement
        if (rb.velocity.magnitude <= 2f && !inCombat)
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
    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currentHealth / maxHealth, lerpSpeed);
    }

    void ColorChanger()
    {
        Color healthColor = Color.Lerp(noHealthColor, fullHealthColor, (currentHealth / maxHealth));

        healthBar.color = healthColor;
    }

    private void OnMouseEnter()
    {
        rb.velocity = Vector2.zero;
    }

    private void OnMouseDown()
    {
        //

        if (canDrag)
        {
            GetComponent<AudioSource>().clip = stretchSound;
            GetComponent<AudioSource>().Play();
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
            //GetComponent<AudioSource>().clip = stretchSound;
            GetComponent<AudioSource>().Stop();
        }
        

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //hit sound
        GetComponent<AudioSource>().clip = wallHitSound;
        GetComponent<AudioSource>().Play();
        float speed = lastVelocity.magnitude;
        Vector3 direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "TT1")
        {
            tutorialText1.SetActive(true); 
        }
        if (collision.gameObject.tag == "TT2")
        {
            tutorialText2.SetActive(true);
        }
        if (collision.gameObject.tag == "TT3")
        {
            tutorialText3.SetActive(true);
        }
        if (collision.gameObject.tag == "TT4")
        {
            tutorialText4.SetActive(true);
        }
        if (collision.gameObject.tag == "TT5")
        {
            tutorialText5.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "TT1")
        {
            tutorialText1.SetActive(false);
        }
        if (collision.gameObject.tag == "TT2")
        {
            tutorialText2.SetActive(false);
        }
        if (collision.gameObject.tag == "TT3")
        {
            tutorialText3.SetActive(false);
        }
        if (collision.gameObject.tag == "TT4")
        {
            tutorialText4.SetActive(false);
        }
        if (collision.gameObject.tag == "TT5")
        {
            tutorialText5.SetActive(false);
        }
    }
}
