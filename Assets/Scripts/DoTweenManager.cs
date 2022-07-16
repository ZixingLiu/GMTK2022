using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenManager : MonoBehaviour
{
    public Vector3 targetPos = Vector3.zero;

    public float duration = 1;

    public Ease moveEase = Ease.Linear;

    public enum DotweenType
    {
        moveOneway,moveTwoway, moveBackAndForth
    }
    public DotweenType dotweenType = DotweenType.moveOneway;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            PlayAnimatetion();
        }
    }

    public void PlayAnimatetion()
    {
        if (dotweenType == DotweenType.moveOneway)
        {
            if (targetPos == Vector3.zero)
            {
                targetPos = this.transform.position;
            }

            this.transform.DOMove(targetPos, duration).SetEase(moveEase);
        }
        else if (dotweenType == DotweenType.moveTwoway)
        {
            if (targetPos == Vector3.zero)
            {
                targetPos = this.transform.position;
            }

            StartCoroutine(moveWithBothWay());
        }
        else if(dotweenType == DotweenType.moveBackAndForth)
        {
            if (targetPos == Vector3.zero)
            {
                targetPos = this.transform.position;
            }
            StartCoroutine(moveBackAndForth());
        }
    }


   

    private IEnumerator moveWithBothWay()
    {
        Vector3 orginalPos = this.transform.position;
        this.transform.DOMove(targetPos,duration).SetEase(moveEase);
        yield return new WaitForSeconds(duration);
        this.transform.DOMove(orginalPos,duration).SetEase(moveEase);
    }

    private IEnumerator moveBackAndForth()
    {
        while(true)
        {
            Vector3 orginalPos = this.transform.position;
            this.transform.DOMove(targetPos, duration).SetEase(moveEase);
            yield return new WaitForSeconds(duration);
            this.transform.DOMove(orginalPos, duration).SetEase(moveEase);
            yield return new WaitForSeconds(duration);

        }

    }

}
