using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Monster : MonoBehaviour
{

    public int damage;


    public GameObject Player;
    public DoTweenManager doTween;

    public GameObject rewardCanvas;
    public GameObject combatCnavas;
    GameObject canvas;

    [Header("health")]
    public float maxHealth = 100;
    public float currentHealth;
    public Image healthBar;
    public TextMeshProUGUI healthText;
    float lerpSpeed;

    public Color fullHealthColor;
    public Color noHealthColor;
    private void Awake()
    {
        Player = FindObjectOfType<PlayerControl>().gameObject;
        doTween = GetComponent<DoTweenManager>();
        canvas = GameObject.Find("Canvas");
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //debug
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentHealth += 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentHealth -= 1;
        }

        // health

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("die");
        }
        healthText.text = currentHealth + "/" + maxHealth;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();

        if (currentHealth <= 0)
        {
            //open reward
            combatCnavas.SetActive(false);
            rewardCanvas.SetActive(true);
            rewardCanvas.transform.SetParent(canvas.transform);

            Destroy(this.gameObject);
        }
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

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
    }

    public void attack()
    {
        //GameObject player = Player;
        //doTween.targetPos = player.transform.position;
        //doTween.PlayAnimatetion();

        Player.GetComponent<PlayerControl>().currentHealth -= damage;
    }
}
