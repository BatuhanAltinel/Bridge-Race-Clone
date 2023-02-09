using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public Transform playerStackHolder;
    Transform stairStackHolder;
    GameObject stairTrigger;
    Vector3 lastBrickPos;
    Vector3 targetStairPos;
    int brickIndex = 0;
    [SerializeField] float timeToMove = 1.5f;
    [HideInInspector] public List<Brick> bricks = new();
    public float brickOffsetY = 0.3f;

    public float stairOffsetZ;
    public float stairOffsetY;
    
    void OnTriggerEnter(Collider other)
    {
        BrickStacking(other);
        // if(other.CompareTag("Stair"))
        // {
        //     stairTrigger = other.gameObject;
        //     stairStackHolder = other.gameObject.GetComponentInParent<StairStates>().stairStackHolder.transform;
        //     // stairOffsetZ = other.gameObject.GetComponentInParent<StairStates>().stairOffsetZ;
        //     // stairOffsetY = other.gameObject.GetComponentInParent<StairStates>().stairOffsetY;
        //     BrickToStair();
        // }
            
    }

    private void BrickToStair()
    {
        
        int index = bricks.Count -1;
        if(index >= 0)
        {
            Brick brick = bricks[index];
            brick.GetComponent<CapsuleCollider>().isTrigger = false;
            bricks.Remove(bricks[index]);
            

            brick.transform.parent = stairStackHolder;
            brick.transform.localPosition = stairTrigger.transform.localPosition;
            brick.transform.localRotation = Quaternion.identity;

            
            brick.GetComponent<CapsuleCollider>().height = 2;
            brick.GetComponent<Brick>().StairScale();
            
            stairOffsetY += 0.3f;
            stairOffsetZ += 0.3f;
            targetStairPos = new Vector3(stairTrigger.transform.localPosition.x,0.2f + stairOffsetY,stairOffsetZ - 0.15f);
            stairTrigger.transform.localPosition = targetStairPos;
            
            index--;
        }
        
    }

    private void BrickStacking(Collider other)
    {
        if(other.gameObject.TryGetComponent<Brick>(out Brick brick))
        {
            if(other.gameObject.TryGetComponent<ColorEnum>(out ColorEnum colorEnum) && gameObject.TryGetComponent<ColorEnum>(out ColorEnum PcolorEnum))
            {
                if (colorEnum.colorType == PcolorEnum.colorType )
                {
                    bricks = GameManager.instace.SetTheBrickList(PcolorEnum);
                    bricks.Add(brick);

                    other.gameObject.transform.parent = this.playerStackHolder.transform;
                    lastBrickPos = this.playerStackHolder.transform.position;

                    brick.BrickBouncing();

                    lastBrickPos.y += (bricks.Count-1) * brickOffsetY;
                    brick.MoveTo(lastBrickPos, timeToMove);

                    // Debug.Log(nameof(bricks) + " list Count: " + bricks.Count);
                    brickIndex++;
                    }
                    
                }   
            } 
        }
    }


