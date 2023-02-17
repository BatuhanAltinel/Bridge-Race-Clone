using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StairStates : MonoBehaviour
{
    public GameObject stairTrigger;
    public GameObject stairStackHolder;
    Vector3 stairTriggerStartPos;

    public float stairOffsetZ = 0;
    public float stairOffsetY = 0;

    int pastBrickIndex = 0;
    int brickIndexOnStair = 0;

    bool colorChanged;

    List<Brick> bricks = new();
    List<Brick> bricksOnStair = new();
    StairColorDetector stairColorDetector;

    void Start()
    {
        stairColorDetector = GetComponent<StairColorDetector>();
        stairTriggerStartPos = stairTrigger.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<ColorEnum>(out ColorEnum pColorEnum))
        {
            Debug.Log("Detector detected player");
            bricks = GameManager.instace.SetTheBrickList(pColorEnum);
            int index = bricks.Count -1;

            if(!stairColorDetector.IsColorMacthed(pColorEnum))
            {
                stairOffsetY = 0;
                stairOffsetZ = 0;
                stairColorDetector.colEnum.colorType = pColorEnum.colorType;
                
                colorChanged = true;
                
            }
            
            if(colorChanged)
            {
                int pastStairNum = brickIndexOnStair;
                ReturnToBricksToGround(bricksOnStair[pastBrickIndex],pastStairNum);
            }
           
            if(index >= 0)
            {
                
                Brick brick = bricks[index];
                bricksOnStair.Add(bricks[index]);
                brickIndexOnStair++;

                brick.GetComponent<CapsuleCollider>().isTrigger = false;
                bricks.Remove(bricks[index]);
                

                brick.transform.parent = stairStackHolder.transform;
                brick.transform.localPosition = stairTrigger.transform.localPosition;
                brick.transform.localRotation = Quaternion.identity;

                
                brick.GetComponent<CapsuleCollider>().height = 1;
                brick.GetComponent<Brick>().StairScale();
                
                stairOffsetY += 0.3f;
                stairOffsetZ += 0.3f;
                Vector3 targetStairPos = new Vector3(stairTrigger.transform.localPosition.x,0.2f + stairOffsetY,stairOffsetZ - 0.15f);
                stairTrigger.transform.localPosition = targetStairPos;
                
                index--;
            }
        
        }
    }

    void ReturnToBricksToGround(Brick brick,int indx)
    {
        if(pastBrickIndex < indx)
        {
            brick.transform.parent = null;
            brick.GetComponent<Brick>().GotoFirstPosition();
            brick.GetComponent<CapsuleCollider>().isTrigger = true;
            brick.transform.localScale = new Vector3(1,0.3f,0.3f);
            brickIndexOnStair--;
            pastBrickIndex++;
            return;    
        }else
        {
            colorChanged = false;
            pastBrickIndex = 0;
        }
            
        
    }
    

}
