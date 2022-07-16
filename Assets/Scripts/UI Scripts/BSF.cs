using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSF : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip buttonSound;
    public AudioClip hitSound;
    public AudioClip diceRoll; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ButtonSoundPlay()
    {
        GetComponent<AudioSource>().clip = buttonSound;
        GetComponent<AudioSource>().Play();
    }
    public void HitSoundPlay()
    {
        GetComponent<AudioSource>().clip = hitSound;
        GetComponent<AudioSource>().Play();
    }
    public void RollDiceSound()
    {
        GetComponent<AudioSource>().clip = diceRoll;
        GetComponent<AudioSource>().Play();
    }
}
