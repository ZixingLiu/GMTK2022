using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TreasureCanvas : MonoBehaviour
{

    public GameObject leaveButton;
    PlayerControl playerControl;
    Combat combat;

    public GameObject rightButton, rightReward,leftButton,leftReward;
    private void Awake()
    {
        playerControl = FindObjectOfType<PlayerControl>();
        combat = FindObjectOfType<Combat>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //GameObject anotherButton, GameObject anotherReward
    public void ChooseRight()
    {
        Destroy(leftButton);
        Destroy(leftReward);

        for (int i = 0; i < rightReward.transform.childCount; i++)
        {
            rightReward.transform.GetChild(0).GetChild(i).GetComponent<Reward>().canInteract = true ;
        }

        Destroy(EventSystem.current.currentSelectedGameObject);
        leaveButton.SetActive(true);
    }

    public void ChooseLeft()
    {
        Destroy(rightButton);
        Destroy(rightReward);

        for (int i = 0; i < leftReward.transform.GetChild(0).childCount; i++)
        {
            leftReward.transform.GetChild(0).GetChild(i).GetComponent<Reward>().canInteract = true;
        }

        Destroy(EventSystem.current.currentSelectedGameObject);
        leaveButton.SetActive(true);
    }

    public void ClickLeave()
    {
        playerControl.canDrag = true;
        playerControl.inCombat = false;
        Destroy(combat.targetTreasure);

        Destroy(this.gameObject);
    }
}
