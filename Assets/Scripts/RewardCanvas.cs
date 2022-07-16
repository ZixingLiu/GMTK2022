using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RewardCanvas : MonoBehaviour
{
    PlayerControl playerControl;

    private void Awake()
    {
        playerControl = FindObjectOfType<PlayerControl>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickLeave()
    {
        playerControl.canDrag = true;
        playerControl.inCombat = false;

        Destroy(this.gameObject);
    }
}
