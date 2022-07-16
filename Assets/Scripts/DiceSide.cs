using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiceSide : MonoBehaviour, IDropHandler
{

    public int damage;
    public int shield;

    Combat combat;

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
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<Reward>() != null)
        {
            Reward reward = eventData.pointerDrag.GetComponent<Reward>();

            eventData.pointerDrag.transform.SetParent(this.transform);
            eventData.pointerDrag.transform.position = transform.position;
            reward.moveBack = false;
            reward.canInteract = false;

            if(reward.currentRewardType == Reward.rewardType.attackReward)
            {
                combat.playerDamage++;
            }
            else if(reward.currentRewardType == Reward.rewardType.shieldReward)
            {
                combat.playerShield++;
            }
        }
    }
}