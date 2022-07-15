using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialog dialog;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialog);
    }
}
