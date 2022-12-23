using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    StackManager stackManager;
    public Vector3 offSet;
    bool canCameraMove = true;
    int offsetCount = 10;
    [SerializeField] float _followSpeed = 2f;
    
    void Awake()
    {
        stackManager = playerTransform.gameObject.GetComponent<StackManager>();
        offSet = new Vector3(0,13,-13);
    }
    private void LateUpdate() 
    {
        FollowPlayer();    
        CameraOffsetSetting();    
    }

    void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position , playerTransform.position + offSet,_followSpeed * Time.deltaTime);
    }

    void CameraOffsetSetting()
    {
        if(stackManager.bricks.Count > offsetCount && canCameraMove)
        {
            offSet.y += 1;
            offSet.z -= 1;
            offsetCount += 7;

            if(offSet.y >= 17 || offSet.z <= -17)
            {
                canCameraMove = false;
            }
        }
    }

}
