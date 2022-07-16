using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Reward : MonoBehaviour,IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public enum rewardType { normal, special}
    public rewardType currentRewardType;

    public bool canInteract = true;
    public bool moveBack;
    CanvasGroup canvasGroup;

    GameObject rewardInScene;
    GameObject currentHolder;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rewardInScene = GameObject.Find("Reward in Scene");
        currentHolder = transform.parent.gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canInteract)
        {
            
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0.6f;

            moveBack = true;
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canInteract)
        {
            //rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            transform.SetParent(rewardInScene.transform);

            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canInteract)
        {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1;

            if (moveBack)
            {
                transform.SetParent(currentHolder.transform);

            }
        }

    }
}
