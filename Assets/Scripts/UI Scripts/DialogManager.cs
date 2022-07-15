using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    private Queue<string> sentences;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;

    public GameObject dialogBar;
    public GameObject nameBar; 
    public GameObject continueButton;
    public GameObject triggerButton;

    public string MainScene;
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialog dialog)
    {

        nameText.text = dialog.name;
        sentences.Clear();
        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }
    public void EndDialog()
    {
        Debug.Log("End og the conversation");
        SceneManager.LoadScene(MainScene);
    }
    public void TrunOnTextTrigger()
    {
        dialogBar.SetActive(true);
        nameBar.SetActive(true);
        continueButton.SetActive(true); 
        triggerButton.SetActive(false);
        
    }
}

