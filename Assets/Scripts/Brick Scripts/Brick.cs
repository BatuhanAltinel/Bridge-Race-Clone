using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Brick : MonoBehaviour
{
    bool isReached;
    Vector3 spawnedPosition;

    public void GroundPosition(Vector3 pos)
    {
       spawnedPosition = pos;
    }

    public void BrickBouncing()
    {
        transform.DOScale(new Vector3(1.3f,0.5f,0.5f),0.2f).SetEase(Ease.InOutBounce).
        OnComplete(() => transform.DOScale(new Vector3(1f,0.3f,0.3f),0.2f).SetEase(Ease.InOutBounce));
        
    }
    public void BrickMove(Transform parent,Vector3 destination,float timeToMove,float yPos)
    {
        StartCoroutine(BrickMoveRoutine(parent,destination,timeToMove,yPos));
    }
     
    IEnumerator BrickMoveRoutine(Transform parent,Vector3 destination,float timeToMove,float yPos)
    {
        float elapsedTime = 0;
        isReached = false;

        while(!isReached)
        {
            if(Vector3.Distance(transform.position,destination) < 0.5f)
            {
                isReached = true;
                transform.position = destination;
                StartCoroutine(BrickChildPositioning(timeToMove,parent,yPos));
            }

            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp(elapsedTime/timeToMove,0,1);

            transform.position = Vector3.Lerp(transform.position,destination,t);
            
            // yield return null;
            yield return new WaitForEndOfFrame();
        }
    }
    

    IEnumerator BrickChildPositioning(float timeToMove,Transform parent,float yPos)
    {
        yield return new WaitForEndOfFrame();
        transform.localPosition = new Vector3(0,yPos,0);
        transform.localRotation = Quaternion.identity;
    }

    
}
