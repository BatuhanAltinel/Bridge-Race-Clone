using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    ColorEnum colorEnum;
    public GameObject stackPoint;
    bool isReached;
    void Awake()
    {
        colorEnum = GetComponent<ColorEnum>();
        stackPoint = GameObject.Find("Stack Point");
    }

    public void GroundPosition(Vector3 pos)
    {
       transform.position = pos;
    }

    public void BrickMove(Transform destination,float timeToMove)
    {
        StartCoroutine(BrickMoveRoutine(destination,timeToMove));
    }
     
    IEnumerator BrickMoveRoutine(Transform destination,float timeToMove)
    {
        float elapsedTime = 0;
        isReached = false;

        while(!isReached)
        {
            if(Vector3.Distance(transform.position,destination.position) <0.1f)
            {
                isReached = true;
                transform.position = destination.position;
                transform.parent = destination;
                transform.localRotation = Quaternion.identity;
                transform.localPosition = Vector3.zero;
            }

            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp(elapsedTime/timeToMove,0,1);

            transform.position = Vector3.Lerp(transform.position,destination.position,t);
            yield return new WaitForEndOfFrame();
        }

        
        
    }
    
}
