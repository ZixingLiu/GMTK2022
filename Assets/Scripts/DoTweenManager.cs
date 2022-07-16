using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenManager : MonoBehaviour
{
    public Vector3 targetPos = Vector3.zero;

    public float duration = 1;
    public int shakeTime =4;
    public float shakeMagnitude;

    public Ease moveEase = Ease.Linear;

    public enum DotweenType
    {
        moveOneway,moveTwoway, moveBackAndForth,shake
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
        else if(dotweenType == DotweenType.shake)
        {
            if (targetPos == Vector3.zero)
            {
                targetPos = this.transform.position;
            }
            StartCoroutine(Shake(shakeTime));
        }
    }

    private IEnumerator Shake(int shakeTimes)
    {
        for(int i=0;i<shakeTimes;i++)
        {
            Debug.Log("shake");
            Vector3 orginalPos = this.transform.position;
            targetPos = orginalPos + new Vector3(Random.Range(-shakeMagnitude, shakeMagnitude), Random.Range(-shakeMagnitude, shakeMagnitude));
            this.transform.DOMove(targetPos, duration).SetEase(moveEase);
            yield return new WaitForSeconds(duration);
            this.transform.DOMove(orginalPos, duration).SetEase(moveEase);
            yield return new WaitForSeconds(duration);
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
