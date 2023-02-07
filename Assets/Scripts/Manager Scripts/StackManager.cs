using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public Transform playerStackHolder;
    public Transform stairStackHolder;
    public GameObject stairTrigger;
    Vector3 lastBrickPos;
     Vector3 targetStairPos;
    int brickIndex = 0;
    [SerializeField] float timeToMove = 1.5f;
    [HideInInspector] public List<Brick> bricks = new();
    public float brickOffsetY = 0.3f;

    public float stairOffsetZ = 0;
    public float stairOffsetY = 0;
    
    void OnTriggerEnter(Collider other)
    {
        BrickStacking(other);
        if(other.CompareTag("Stair"))
            BrickToStair();
    }

    private void BrickToStair()
    {
        
        int index = bricks.Count -1;
        if(index >= 0)
        {
            Brick brick = bricks[index];
            brick.GetComponent<BoxCollider>().isTrigger = false;
            bricks.Remove(bricks[index]);
            targetStairPos = new Vector3(0,0.2f+stairOffsetY,stairOffsetZ -0.15f);

            brick.transform.parent = stairStackHolder;
            brick.transform.localPosition = stairTrigger.transform.localPosition;
            brick.transform.localRotation = Quaternion.identity;

            
            brick.GetComponent<BoxCollider>().size = new Vector3(1,1,1);
            brick.GetComponent<Brick>().StairScale();
            // brick.GetComponent<Brick>().MoveTo(targetStairPos,0.1f);
            stairOffsetY += 0.3f;
            stairOffsetZ += 0.3f;
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

                    Debug.Log(nameof(bricks) + " list Count: " + bricks.Count);
                    brickIndex++;
                    }
                    
                }   
            } 
        }
    }


