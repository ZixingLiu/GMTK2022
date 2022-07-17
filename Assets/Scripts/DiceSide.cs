using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiceSide : MonoBehaviour, IDropHandler
{

    public int damage;
    public int shield;

    Combat combat;

    bool canAdd = true;
    private void Awake()
    {
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
    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount < 4 )
        {
            if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<Reward>() != null && canAdd)
            {
                Reward reward = eventData.pointerDrag.GetComponent<Reward>();

                if(reward.canInteract)
                {
                    if (reward.currentRewardType == Reward.rewardType.attackReward)
                    {
                        damage++;
                    }
                    else if (reward.currentRewardType == Reward.rewardType.shieldReward)
                    {
                        shield += 2;
                    }
                    else if (reward.currentRewardType == Reward.rewardType.attackSpecial)
                    {

                        foreach (Transform child in transform)
                        {
                            GameObject.Destroy(child.gameObject);
                        }

                        damage = 10;
                        canAdd = false;
                    }
                    else if (reward.currentRewardType == Reward.rewardType.shieldSpecial)
                    {

                        foreach (Transform child in transform)
                        {
                            GameObject.Destroy(child.gameObject);
                        }

                        shield = 10;
                        canAdd = false;
                    }

                    eventData.pointerDrag.transform.SetParent(this.transform);
                    eventData.pointerDrag.transform.position = transform.position;
                    reward.moveBack = false;
                    reward.canInteract = false;
                }

                
            }
        }
        
    }
}
